using UnityEngine;

public class Meteor_Behavior : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 pos = new Vector3(0, -1, 0);
        transform.Translate(pos * 20 * Time.deltaTime, Space.World); 

        if (transform.position.y < 0f) {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.tag == "Team1" || enemy.tag == "Team2")
            {
                enemy.GetComponent<AbstractUnitBehavior>().getDamaged(100);
            }
        }
        Destroy(gameObject);
    }


}
