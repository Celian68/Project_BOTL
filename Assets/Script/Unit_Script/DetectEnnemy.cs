using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    public int rotation = 1;
    
    // Update is called once per frame
    void Update()
    {
        ManagePosition();
    }

    public void ManagePosition()
    {
        transform.localScale = new Vector3(transform.parent.GetComponent<AbstractUnitBehavior>().unitRange * transform.parent.transform.localScale.x, transform.parent.transform.localScale.y, 1);
        transform.localPosition = new Vector3(transform.localScale.x / 2 /transform.parent.transform.localScale.x * transform.parent.GetComponent<AbstractUnitBehavior>().getTeamMultipl() * rotation, 0, 0);
    }

    public Collider2D[] EnemiesDetection() {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0, LayerMask.GetMask(transform.parent.GetComponent<AbstractUnitBehavior>().getEnemyTeam()));

        return hitColliders;
    }

    public void setRotation(int rotation) {
        this.rotation = rotation;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
