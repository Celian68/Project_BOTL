using UnityEngine;

public class Manage_Dead_Unit : MonoBehaviour
{

    public GameObject deathAnimation;

    public void spawn_Dead_Unit(Vector3 position) {
        Instantiate(deathAnimation, position, Quaternion.identity);
    }
}
