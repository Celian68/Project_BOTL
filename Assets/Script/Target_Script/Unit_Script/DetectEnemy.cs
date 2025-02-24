using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DetectEnemy : MonoBehaviour
{
    float rotation = 1;
    
    // Update is called once per frame
    void Update()
    {
        ManagePosition();
    }

    public void ManagePosition()
    {
        transform.localScale = new Vector3(transform.parent.GetComponent<AbstractUnit>().GetUnitStats().unitRange * transform.parent.transform.localScale.x, transform.parent.transform.localScale.y, 1);
        transform.localPosition = new Vector3(transform.localScale.x / 2 /transform.parent.transform.localScale.x * transform.parent.GetComponent<AbstractUnit>().GetTeamMultipl() * rotation, 0, 0);
    }

    public List<Collider2D> EnemiesDetection() {
        List<Collider2D> allyColliders = new List<Collider2D>();
        List<Collider2D> hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, LayerMask.GetMask("Unit")).ToList();
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<ItTarget>().GetTeam() == transform.parent.GetComponent<ItTarget>().GetTeam())
            {
                allyColliders.Add(hitCollider);
            }

        }
        foreach (Collider2D hitCollider in allyColliders)
        {
            hitColliders.Remove(hitCollider);

        }
        return hitColliders;
    }

    public void SetRotation(float rotation) {
        this.rotation = rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
