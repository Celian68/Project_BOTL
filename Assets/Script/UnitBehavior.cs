using UnityEngine;
using System.Collections;

public class UnitBehavior : MonoBehaviour
{

    public float moveSpeed;
    public float unitRange;
    public float life;
    public float attackSpeed;
    public float damage;

    public Transform target;
    public Transform enemyTarget;
 
    public string enemyTag;

    public Animator animator;

    private GameObject castle;

    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        //Check every 0.3sec fonction "UpdateTarget"; Parama ["Fonction"], Wait to start, check delay
        InvokeRepeating("UpdateTarget", 0f, 0.3f); 

        if (enemyTag == "Player2") {
            castle = GameObject.FindGameObjectWithTag("Castle2");
        }else{
            castle = GameObject.FindGameObjectWithTag("Castle1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking) {
            Move();
        }
    }

    void UpdateTarget() {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && ((enemyTag == "Player2" && transform.position.x < enemy.transform.position.x) || (enemyTag == "Player1" && transform.position.x > enemy.transform.position.x))) {
                shortestDistance = distanceToEnemy; // Save position of nearest ennemi
                nearestEnemy = enemy; //Set nearest ennemi
            }
        }

        if (castle != null && enemyTarget == castle.transform) {
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

    void Move() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World); 

        if (Vector3.Distance(transform.position, target.position) < 0.3f && castle != null) {
            enemyTarget = castle.transform;
        }else if (castle == null) {
            if (enemyTag == "Player2") {
                target = GameObject.FindGameObjectWithTag("End1").transform;
            }else{
                target = GameObject.FindGameObjectWithTag("End2").transform;
            }

            if (Vector3.Distance(transform.position, target.position) < 0.3f) {
                Destroy(gameObject);
            }
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

    public IEnumerator Attack() {
        isAttacking = true;
        while (enemyTarget != null) {
            animator.SetBool("doDamage", false);
            yield return new WaitForSeconds(attackSpeed);
            if (enemyTarget != null) {
                animator.SetBool("doDamage", true);
                if (enemyTarget == castle.transform) {
                    castle.GetComponent<Castle>().getDamaged(damage);
                }else{
                    enemyTarget.GetComponent<UnitBehavior>().getDamaged(damage);
                }
                yield return new WaitForSeconds(0.3f);  //delay(3000)
            }else{
                enemyTarget = null;
            }
        }
        isAttacking = false;
    }

    void getDamaged(float damage) {
        life -= damage;
        if (life <= 0) {
            Destroy(gameObject);
        }
    }
}
