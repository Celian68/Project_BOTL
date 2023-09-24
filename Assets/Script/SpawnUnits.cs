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
                spawnUnit1();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                spawnUnit2();
            }

        }else{

            if (Input.GetKeyDown(KeyCode.Alpha6)) {
                spawnUnit1();
            }

            if (Input.GetKeyDown(KeyCode.Alpha7)) {
                spawnUnit2();
            }

        }

    }

    public void spawnUnit1() {
        if (castle.GetComponent<Castle>().looseRessources(unite2.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite1, transform);
        }
    }

    public void spawnUnit2() {
        if (castle.GetComponent<Castle>().looseRessources(unite2.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite2, transform);
        }
    }

    public void spawnUnit3() {
        if (castle.GetComponent<Castle>().looseRessources(unite2.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite3, transform);
        }
    }

    public void spawnUnit4() {
        if (castle.GetComponent<Castle>().looseRessources(unite2.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite4, transform);
        }
    }

    public void spawnUnit5() {
        if (castle.GetComponent<Castle>().looseRessources(unite2.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite5, transform);
        }
    }
}
