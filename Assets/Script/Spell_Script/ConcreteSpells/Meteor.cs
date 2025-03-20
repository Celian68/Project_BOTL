using System.Collections.Generic;
using System.Linq;
using BOTL.Data;
using UnityEngine;

public class Meteor : AbstractSpell
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

    protected void Explode()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 1.5f);

        List<Transform> units = enemies
            .Where(enemy => enemy.GetComponent<AbstractUnit>() != null 
            && (enemy.CompareTag("Team1") || enemy.CompareTag("Team2")))
            .Select(enemy => enemy.GetComponent<AbstractUnit>().transform)
            .ToList();

        StartTrigger(TriggerType.OnImpact, units);

        GameObject explosionWave = Instantiate(explosionWavePrefab, transform.position, Quaternion.identity);
        explosionWave.SetActive(true);
        explosionWave.GetComponent<ExplosionWaveBehavior>().SetDataParent(data);

        Destroy(gameObject);
    }
}
