using UnityEngine;

public class DeadUnitManager : MonoBehaviour
{

    public static DeadUnitManager _instance;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    public GameObject deathAnimation;

    public void SpawnDeadUnit(Vector3 position)
    {
        Instantiate(deathAnimation, position, Quaternion.identity);
    }
}
