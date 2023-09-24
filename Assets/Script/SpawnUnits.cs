using UnityEngine;

public class SpawnUnits : MonoBehaviour
{

    public GameObject unite1;
    public GameObject unite2;
    public GameObject unite3;
    public GameObject unite4;
    public GameObject unite5;

    // Update is called once per frame
    void Update()
    {
        spawnUnits();
    }

    void spawnUnits() {
        if (gameObject.tag == "Spawn1") {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Instantiate(unite1, transform);
            }
        }else{
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Instantiate(unite1, transform);
            }
        }

    }
}
