using UnityEngine;

public class Meteor_Behavior : MonoBehaviour
{

    public GameObject explosionWavePrefab;

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 pos = new Vector3(0, -1, 0);
        transform.Translate(pos * 20 * Time.deltaTime, Space.World);

        if (transform.position.y < 0f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 1.5f);
        foreach (Collider2D enemy in enemies)
        {
            AbstractUnit unit = enemy.GetComponent<AbstractUnit>();
            if (unit != null && (enemy.CompareTag("Team1") || enemy.CompareTag("Team2")))
            {
                unit.GetDamaged(100);
            }
        }

        GameObject explosionWave = Instantiate(explosionWavePrefab, transform.position, Quaternion.identity);
        explosionWave.SetActive(true);

        Destroy(gameObject);
    }


}
