using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DetectUnit : MonoBehaviour
{
    float rotation = 1;

    void Update()
    {
        ManagePosition();
    }

    public void ManagePosition()
    {
        transform.localScale = new Vector3(transform.parent.GetComponent<AbstractUnit>().GetUnitStats().attackRange * transform.parent.transform.localScale.x, transform.parent.transform.localScale.y, 1);
        transform.localPosition = new Vector3(transform.localScale.x / 2 / transform.parent.transform.localScale.x * transform.parent.GetComponent<AbstractUnit>().GetTeamMultipl() * rotation, 0, 0);
    }

    public List<Collider2D> EnemiesDetection()
    {
        var parentTeam = transform.parent.GetComponent<ITTarget>().GetTeam();
        return Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, LayerMask.GetMask("Unit"))
            .Where(col => col.GetComponent<ITTarget>() != null && col.GetComponent<ITTarget>().GetTeam() != parentTeam)
            .ToList();
    }

    public List<Collider2D> AlliesDetection()
    {
        var parentTeam = transform.parent.GetComponent<ITTarget>().GetTeam();
        return Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, LayerMask.GetMask("Unit"))
            .Where(col => col.GetComponent<ITTarget>() != null && col.GetComponent<ITTarget>().GetTeam() == parentTeam)
            .ToList();
    }

    public void SetRotation(float rotation)
    {
        this.rotation = rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
