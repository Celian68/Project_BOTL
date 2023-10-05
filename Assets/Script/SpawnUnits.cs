using UnityEngine;
using UnityEngine.UI;

public class SpawnUnits : MonoBehaviour
{

    public GameObject unite1;
    public GameObject unite2;
    public GameObject unite3;
    public GameObject unite4;
    public GameObject unite5;

    public GameObject unite6;
    public GameObject unite7;
    public GameObject unite8;
    public GameObject unite9;
    public GameObject unite10;


    private GameObject castle1;
    private GameObject castle2;

    private Transform spawn1;
    private Transform spawn2;

    void Start() {
        castle1 = GameObject.FindGameObjectWithTag("Castle1");
        castle2 = GameObject.FindGameObjectWithTag("Castle2");
        spawn1 = GameObject.FindGameObjectWithTag("Spawn1").transform;
        spawn2 = GameObject.FindGameObjectWithTag("Spawn2").transform;
    }

    // Update is called once per frame
    void Update() {
        spawnUnits();
    }

    void spawnUnits() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            UnitButton1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            UnitButton2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            UnitButton3();
        }

        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            UnitButton4();
        }
    }

    public void UnitButton1() {
        if (castle1.GetComponent<Castle>().looseRessources(unite1.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite1, spawn1);
        }
    }

    public void UnitButton2() {
        if (castle1.GetComponent<Castle>().looseRessources(unite2.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite2, spawn1);
        }
    }

    public void UnitButton3() {
        if (castle2.GetComponent<Castle>().looseRessources(unite6.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite6, spawn2);
        }
    }

    public void UnitButton4() {
        if (castle2.GetComponent<Castle>().looseRessources(unite7.GetComponent<UnitBehavior>().cost)) {
            Instantiate(unite7, spawn2);
        }
    }
}
