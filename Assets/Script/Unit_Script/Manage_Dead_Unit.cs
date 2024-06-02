using UnityEngine;

public class Manage_Dead_Unit : MonoBehaviour
{

    public static Manage_Dead_Unit _instance;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }
    
    public GameObject deathAnimation;

    public void spawn_Dead_Unit(Vector3 position) {
        Instantiate(deathAnimation, position, Quaternion.identity);
    }
}
