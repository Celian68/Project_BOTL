using UnityEngine;
using UnityEngine.UI;

public class Spawn_Manager : MonoBehaviour
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


    Transform spawn1;
    Transform spawn2;

    public static Spawn_Manager _instance;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    void Start() {
        spawn1 = GameObject.FindGameObjectWithTag("Spawn1").transform;
        spawn2 = GameObject.FindGameObjectWithTag("Spawn2").transform;
    }

    public void UnitButton1() {
        if (RessourceManager._instance.ConsumResources(unite1.GetComponent<UnitBehavior>().cost, false)) {
            spawn_Unit(unite1, spawn1);
        }
    }

    public void UnitButton2() {
        if (RessourceManager._instance.ConsumResources(unite2.GetComponent<UnitBehavior>().cost, false)) {
            spawn_Unit(unite2, spawn1);
        }
    }

    public void UnitButton3() {
        if (RessourceManager._instance.ConsumResources(unite3.GetComponent<UnitBehavior>().cost, false)) {
            spawn_Unit(unite3, spawn1);
        }
    }

    public void UnitButton4() {
        if (RessourceManager._instance.ConsumResources(unite4.GetComponent<UnitBehavior>().cost, false)) {
            spawn_Unit(unite4, spawn1);
        }
    }

    public void UnitButton5() {
        if (RessourceManager._instance.ConsumResources(unite5.GetComponent<UnitBehavior>().cost, false)) {
            spawn_Unit(unite5, spawn1);
        }
    }

    public void UnitButton6() {
        if (RessourceManager._instance.ConsumResources(unite6.GetComponent<UnitBehavior>().cost, true)) {
            spawn_Unit(unite6, spawn2);
        }
    }

    public void UnitButton7() {
        if (RessourceManager._instance.ConsumResources(unite7.GetComponent<UnitBehavior>().cost, true)) {
            spawn_Unit(unite7, spawn2);
        }
    }

    public void UnitButton8() {
        if (RessourceManager._instance.ConsumResources(unite8.GetComponent<UnitBehavior>().cost, true)) {
            spawn_Unit(unite8, spawn2);
        }
    }

    public void UnitButton9() {
        if (RessourceManager._instance.ConsumResources(unite9.GetComponent<UnitBehavior>().cost, true)) {
            spawn_Unit(unite9, spawn2);
        }
    }

    public void UnitButton10() {
        if (RessourceManager._instance.ConsumResources(unite10.GetComponent<UnitBehavior>().cost, true)) {
            spawn_Unit(unite10, spawn2);
        }
    }

    public void spawn_Unit(GameObject unit, Transform spawn) {
        float randomNumber = Random.Range(23, 65)/100f;
        spawn.position = new Vector3(spawn.position.x, randomNumber, 0);
        Instantiate(unit, spawn.position, Quaternion.identity);   
    }
}
