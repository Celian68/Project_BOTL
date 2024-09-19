using UnityEngine;
using System.Collections;
using Unity.Collections;
using System;


public abstract class AbstractUnitBehavior : MonoBehaviour
{

    public float maxLife;
    protected float life;
    public float damage;
    public float moveSpeed;
    public float unitRange;
    public float attackSpeed;

    protected float teamMultipl;
    protected string enemyTeam;
    protected bool isAttacking = false;

    protected Transform enemyTarget;
    protected Collider2D[] enemiesInRange;
    string castle;

    public Animator animator;

    DetectEnemy detectEnemy;


    protected virtual void Start()
    {
        if (gameObject.transform.position.x < 0) {
            enemyTeam = "Team2";
            transform.tag = "Team1";
            teamMultipl = 1;
            gameObject.layer = LayerMask.NameToLayer("Team1");
            castle = "Castle2";
        }else {
            enemyTeam = "Team1";
            transform.tag = "Team2";
            teamMultipl = -1;
            gameObject.layer = LayerMask.NameToLayer("Team2");
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            castle = "Castle1";
        }
        life = maxLife;

        InvokeRepeating("Behavior", 0f, 0.2f);
        detectEnemy = GetComponentInChildren<DetectEnemy>();
    }

    protected virtual void Behavior() {
        CheckEnemyInRange();
        if (!isAttacking && enemyTarget != null) {
            animator.SetBool("EnemyFound", true);
            StartCoroutine(Attack());
        }
    }

    void CheckEnemyInRange() {
        enemiesInRange = detectEnemy.EnemiesDetection();

        if (enemiesInRange.Length > 0 && !isAttacking) {
            enemyTarget = enemiesInRange[0].transform;
        }else if (enemiesInRange.Length == 0) {
            enemyTarget = null;
        }
    }

    protected virtual void Move() {
        Vector3 tar = new Vector3(teamMultipl, 0, 0);
        transform.Translate(tar.normalized * moveSpeed * Time.deltaTime, Space.World); 

        if (transform.position.x < -15f || transform.position.x > 45f) {
            Destroy(gameObject);
        }
    }

    protected IEnumerator Attack() {
        isAttacking = true;
        while (checkEnemyState()) {
            animator.SetBool("doDamage", false);
            yield return new WaitForSeconds(attackSpeed);
            if (checkEnemyState()) {
                animator.SetBool("doDamage", true);
                yield return new WaitForSeconds(0.25f);
                if (checkEnemyState()) {
                    if (enemyTarget.tag == castle) {
                        GameObject.FindGameObjectWithTag(castle).GetComponent<Castle>().getDamaged(damage);
                    }else{
                        enemyTarget.GetComponent<AbstractUnitBehavior>().getDamaged(damage);
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        enemyTarget = null;
        isAttacking = false;
        animator.SetBool("EnemyFound", false);
    }

    public virtual void getDamaged(float damage) {
        life -= damage;
        UI_Manager._instance.ShowNumberText(Mathf.RoundToInt(damage), transform.position, teamMultipl, "-");
    }

    public float getLife() {
        return life;
    }

    protected abstract void Die();

    public virtual void Heal(float heal) {
        if (life < maxLife) {
            life += heal;
            if (life > maxLife) {
                life = maxLife;
            }
            UI_Manager._instance.ShowNumberText(Mathf.RoundToInt(heal), transform.position, teamMultipl, "+");
        }
    }

    public void FullHeal() {
        Heal(maxLife);
    }

    public string getEnemyTeam() {
        return enemyTeam;
    }

    public float getTeamMultipl() {
        return teamMultipl;
    }

    bool checkEnemyState() {
        return enemyTarget != null && enemyTarget.gameObject.activeSelf;
    }

    protected void Rotate(int rotation) {
        if (rotation == 1) {
            GetComponent<SpriteRenderer>().flipX = false;
        }else{
            GetComponent<SpriteRenderer>().flipX = true;
        }
        detectEnemy.setRotation(rotation);
    }

    public abstract bool IsHero();
}
