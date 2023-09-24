using UnityEngine;

public class SpawnUnits : MonoBehaviour
{

    public GameObject unite1;
    public GameObject unite2;
    public GameObject unite3;
    public GameObject unite4;
    public GameObject unite5;


    private GameObject castle;

    void Start() {
        castle = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update() {
        spawnUnits();
    }

    void spawnUnits() {

        if (gameObject.tag == "Spawn1") {

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                if (castle.GetComponent<Castle>().looseRessources(unite1.GetComponent<UnitBehavior>().cost)) {
                    Instantiate(unite1, transform);
                }
            }

        }else{

            if (Input.GetKeyDown(KeyCode.Alpha6)) {
                if (castle.GetComponent<Castle>().looseRessources(unite1.GetComponent<UnitBehavior>().cost)) {
                    Instantiate(unite1, transform);
                }
            }

        }

    }
}
