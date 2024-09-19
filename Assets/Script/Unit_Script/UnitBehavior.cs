using UnityEngine;
using System.Collections;


public class UnitBehavior : AbstractUnitBehavior
{

    public int cost;
    public float state;

    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking) {
            Move();
        }
    }

    public override void getDamaged(float damage) {
        
        base.getDamaged(damage);
        Die();
    }

    protected override void Die()
    {
        if (getLife() <= 0) {
            Vector3 newPosition = new Vector3(transform.position.x, (float)(transform.position.y + 0.16), 0);
            Manage_Dead_Unit._instance.spawn_Dead_Unit(newPosition);
            Destroy(gameObject);
        }
    }

    public override bool IsHero() {
        return false;
    }
}
