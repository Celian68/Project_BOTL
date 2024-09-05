using UnityEngine;
using UnityEngine.UI;


public class HeroBehavior : AbstractUnitBehavior
{
    float state;

    public Text lifeCount;

    public Transform respawn;

    protected override void Start() {
        base.Start();
        updateLife();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && state == 1) {
            Move();
        }else if (state == 2) {
            runAway();
        }
    }

    public void Stay() {
        animator.SetBool("Idle", true);
        GetComponent<SpriteRenderer>().flipX = false;
        state = 0;
    }

    public void Right() {
        animator.SetBool("Idle", false);
        GetComponent<SpriteRenderer>().flipX = false;
        state = 1;
    }

    public void Left() {
        animator.SetBool("Idle", false);
        GetComponent<SpriteRenderer>().flipX = true;
        state = 2;
    }

    void updateLife() {
        lifeCount.text = getLife().ToString();
    }

    

    public override void getDamaged(float damage) {  
        base.getDamaged(damage);
        updateLife();
        Die();
    }

    void runAway() {
        Vector3 tar = new Vector3(target.position.x, 0, 0);
        tar *= -1;
        transform.Translate(tar.normalized * moveSpeed * Time.deltaTime, Space.World);
        if (transform.position.x < -13f) {
            Stay();
        }
    }

    protected override void Die()
    {
        if (getLife() <= 0) {
            life = Mathf.Max(life, 0);
            gameObject.SetActive(false);
            Respawn();
        }
    }

    void Respawn() {
        Timer_Factory._instance.StartTimer(10f, () =>
        {
            gameObject.SetActive(true);
            FullHeal();
            updateLife();
            Vector3 newPosition = transform.position;
            newPosition.x = respawn.position.x;
            transform.position = newPosition;
            isAttacking = false;
            Stay();
        });
    }
}
