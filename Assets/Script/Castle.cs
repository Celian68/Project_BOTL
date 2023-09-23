using UnityEngine;

public class Castle : MonoBehaviour
{

    public float life = 500;

    public Transform spawn;

    // Update is called once per frame
    void Update()
    {
        
    }

    void getDamaged(float damage) {
        life -= damage;
        if (life <= 0) {
            Destroy(gameObject);
        }
    }
}
