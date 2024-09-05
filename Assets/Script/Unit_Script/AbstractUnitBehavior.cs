using UnityEngine;
using System.Collections;
using Unity.Collections;


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

    protected Transform target;
    protected Transform endTarget;
    protected Transform enemyTarget;
    GameObject castle;

    public Animator animator;
    protected  SpriteRenderer spriteR;


    protected virtual void Start()
    {
        //Check every 0.3sec fonction "UpdateTarget"; Parama ["Fonction"], Wait to start, check delay
        InvokeRepeating("UpdateTarget", 0f, 0.3f); 

        spriteR = gameObject.GetComponent<SpriteRenderer>();

        if (gameObject.transform.position.x < 0) {
            enemyTeam = "Player2";
            transform.tag = "Player1";
            teamMultipl = 1;
            castle = GameObject.FindGameObjectWithTag("Castle2");
            target = GameObject.FindGameObjectWithTag("Objective1").transform;
            endTarget = GameObject.FindGameObjectWithTag("End1").transform;
        }else {
            enemyTeam = "Player1";
            transform.tag = "Player2";
            teamMultipl = -1;
            castle = GameObject.FindGameObjectWithTag("Castle1");
            target = GameObject.FindGameObjectWithTag("Objective2").transform;
            endTarget = GameObject.FindGameObjectWithTag("End2").transform;
            spriteR.flipX = true;
        }
        life = maxLife;
    }

    protected void UpdateTarget() {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTeam);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && (((transform.position.x + (0.5f * teamMultipl) - enemy.transform.position.x) * teamMultipl) < 0)) {
                shortestDistance = distanceToEnemy; // Save position of nearest ennemi
                nearestEnemy = enemy; //Set nearest ennemi
            }
        }

        if (castle.activeSelf && enemyTarget == castle.transform) {
            if (!isAttacking) {
                animator.SetBool("EnnemyFound", true);
                StartCoroutine(Attack());
            }
        }else if (nearestEnemy != null && shortestDistance <= unitRange + 0.5) {
            enemyTarget = nearestEnemy.transform; 
            if (!isAttacking) {
                animator.SetBool("EnnemyFound", true);
                StartCoroutine(Attack());
            }
        }else{
            animator.SetBool("EnnemyFound", false);
            enemyTarget = null;
        }
    }

    protected virtual void Move() {
        Vector3 tar = new Vector3(target.position.x - transform.position.x, 0, 0);
        transform.Translate(tar.normalized * moveSpeed * Time.deltaTime, Space.World); 

        if (castle.activeSelf && Vector3.Distance(transform.position, target.position) < 0.3f) {
            enemyTarget = castle.transform;
        }else if (!castle.activeSelf) {
            
            target = endTarget;

            if (Vector3.Distance(transform.position, target.position) < 0.3f) {
                Destroy(gameObject);
            }
        }

        if (transform.position.x < -20f || transform.position.x > 45f) {
                Destroy(gameObject);
        }
    }

    // private void OnDrawGizmosSelected() {
       
    //     Gizmos.color = Color.green;

    //     if (enemyTag == "Player1") {
    //         Gizmos.DrawCube(new Vector3(transform.position.x - (unitRange/2), transform.position.y, 0), new Vector3(unitRange * -1, transform.lossyScale.y, 0));
    //     }else{
    //         Gizmos.DrawCube(new Vector3(transform.position.x + (unitRange/2), transform.position.y, 0), new Vector3(unitRange, transform.lossyScale.y, 0));
    //     }
    // }

    protected IEnumerator Attack() {
        isAttacking = true;
        while (enemyTarget != null && enemyTarget.gameObject.activeSelf) {
            animator.SetBool("doDamage", false);
            yield return new WaitForSeconds(attackSpeed);
            if (enemyTarget != null && enemyTarget.gameObject.activeSelf) {
                animator.SetBool("doDamage", true);
                yield return new WaitForSeconds(0.25f);
                if (enemyTarget == castle.transform) {
                    castle.GetComponent<Castle>().getDamaged(damage);
                }else if (enemyTarget != null && enemyTarget.gameObject.activeSelf) {
                    enemyTarget.GetComponent<AbstractUnitBehavior>().getDamaged(damage);
                }
                yield return new WaitForSeconds(0.1f);
            }else{
                enemyTarget = null;
            }
        }
        isAttacking = false;
    }

    public virtual void getDamaged(float damage) {
        life -= damage;
        UI_Manager._instance.ShowNumberText(Mathf.RoundToInt(damage), transform.position, teamMultipl, "-");
    }

    public float getLife() {
        return life;
    }

    protected abstract void Die();

    public void Heal(float heal) {
        life += heal;
        if (life > maxLife) {
            life = maxLife;
        }
        UI_Manager._instance.ShowNumberText(Mathf.RoundToInt(heal), transform.position, teamMultipl, "+");
    }

    public void FullHeal() {
        life = maxLife;
    }
}
