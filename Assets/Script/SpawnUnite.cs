using UnityEngine;
using UnityEngine.UIElements;

public class SpawnUnite : MonoBehaviour
{

    public GameObject unite1;
    public GameObject unite2;

    public Transform spawn1;
    public Transform spawn2;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(unite1, spawn1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(unite2, spawn2);
        }

    }
}