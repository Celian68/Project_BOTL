using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public abstract class AbstractUnitBehavior : MonoBehaviour
{

    public float maxLife;
    protected float life;
    public float damage;
    public float moveSpeed;
    public float unitRange;
    public float attackSpeed;

    protected float teamMultipl;
    protected string myTeam;
    protected string enemyTeam;
    protected bool isAttacking = false;

    protected Transform enemyTarget;
    protected List<Collider2D> enemiesInRange;
    string _enemyCastle;
    public string _allyCastle { get; private set; }

    public Animator animator;
    [SerializeField] Rigidbody2D rb;

    DetectEnemy detectEnemy;


    protected virtual void Start()
    {
        if (gameObject.transform.position.x < 0) {
            enemyTeam = "Team2";
            myTeam = "Team1";
            teamMultipl = 1;
            _enemyCastle = "Castle2";
            _allyCastle = "Castle1";
        }else {
            enemyTeam = "Team1";
            myTeam = "Team2";
            teamMultipl = -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            _enemyCastle = "Castle1";
            _allyCastle = "Castle2";
        }
        rb.excludeLayers = LayerMask.GetMask("Unit");
        life = maxLife;
        transform.tag = myTeam;

        InvokeRepeating("Behavior", 0f, 0.2f);
        detectEnemy = GetComponentInChildren<DetectEnemy>();
    }

    protected virtual void Behavior() {
        CheckEnemyInRange();
        CheckUnitState();
        if (!isAttacking && enemyTarget != null) {
            animator.SetBool("EnemyFound", true);
            StartCoroutine(Attack());
        }
    }

    void CheckEnemyInRange() {
        enemiesInRange = detectEnemy.EnemiesDetection();

        if (enemiesInRange.Count > 0 && !isAttacking) {
            enemyTarget = enemiesInRange[0].transform;
        }else if (enemiesInRange.Count == 0) {
            enemyTarget = null;
        }
    }

    protected virtual void Move() {
        Vector3 tar = new Vector3(teamMultipl, 0, 0);
        transform.Translate(tar.normalized * moveSpeed * Time.deltaTime, Space.World); 
    }

    protected virtual void CheckUnitState() {
        if (transform.position.x < -15f || transform.position.x > 45f || transform.position.y < -5f) {
            Die();
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
                    if (enemyTarget.tag == _enemyCastle) {
                        GameObject.FindGameObjectWithTag(_enemyCastle).GetComponent<Castle>().getDamaged(damage);
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
