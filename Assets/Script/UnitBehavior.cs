using UnityEngine;
using System.Collections;

public class UnitBehavior : MonoBehaviour
{

    public float life;
    public float damage;
    public float cost;
    public float moveSpeed;
    public float unitRange;
    public float attackSpeed;

    private float teamMultipl;
    private string unitTeam;
    private string enemyTeam;
    private bool isAttacking = false;

    private Transform target;
    private Transform endTarget;
    private Transform enemyTarget;
    private GameObject castle;

    public Animator animator;
    private  SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        //Check every 0.3sec fonction "UpdateTarget"; Parama ["Fonction"], Wait to start, check delay
        InvokeRepeating("UpdateTarget", 0f, 0.3f); 

        spriteR = spriteR = gameObject.GetComponent<SpriteRenderer>();

        if (gameObject.transform.parent.gameObject.tag == "Spawn1") {
            unitTeam = "Player1";
            enemyTeam = "Player2";
            transform.tag = "Player1";
            teamMultipl = 1;
            castle = GameObject.FindGameObjectWithTag("Castle2");
            target = GameObject.FindGameObjectWithTag("Objective1").transform;
            endTarget = GameObject.FindGameObjectWithTag("End1").transform;
        }else if (gameObject.transform.parent.gameObject.tag == "Spawn2") {
            unitTeam = "Player2";
            enemyTeam = "Player1";
            transform.tag = "Player2";
            teamMultipl = -1;
            castle = GameObject.FindGameObjectWithTag("Castle1");
            target = GameObject.FindGameObjectWithTag("Objective2").transform;
            endTarget = GameObject.FindGameObjectWithTag("End2").transform;
            spriteR.flipX = true;
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
            
            target = endTarget;

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
