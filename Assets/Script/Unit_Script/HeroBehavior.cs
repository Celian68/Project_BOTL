using UnityEngine;
using UnityEngine.UI;


public class HeroBehavior : AbstractUnitBehavior
{
    float heroState;

    public Text lifeCount;

    Transform respawn;

    protected override void Start() {
        base.Start();
        updateLife();
        respawn = GameObject.Find("Spawn1").transform;
        if (gameObject.transform.position.x < 0) {
            respawn = GameObject.Find("Spawn1").transform;
        }else {
            respawn = GameObject.Find("Spawn2").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking && heroState == 1) {
            Move();
        }else if (heroState == 2) {
            runAway();
        }
    }

    public void Stay() {
        animator.SetBool("Idle", true);
        Rotate(1);
        heroState = 0;
    }

    public void Right() {
        animator.SetBool("Idle", false);
        Rotate(1);
        heroState = 1;
    }

    public void Left() {
        animator.SetBool("Idle", false);
        Rotate(-1);
        heroState = 2;
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
        Vector3 tar = new Vector3(getTeamMultipl(), 0, 0);
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

    public override bool IsHero() {
        return true;
    }

    public override void Heal(float amount) {  
        base.Heal(amount);
        updateLife();
    }
}
