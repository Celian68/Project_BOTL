using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private GameObject spawn1;
    private GameObject spawn2;

    void Start() {
        spawn1 = GameObject.FindGameObjectWithTag("Spawn1");
        spawn2 = GameObject.FindGameObjectWithTag("Spawn2");
    }

    public void UnitButton1() {
        spawn1.GetComponent<SpawnUnits>().spawnUnit1();
    }

    public void UnitButton2() {
        spawn1.GetComponent<SpawnUnits>().spawnUnit2();
    }

    public void UnitButton3() {
        spawn2.GetComponent<SpawnUnits>().spawnUnit1();
    }

    public void UnitButton4() {
        spawn2.GetComponent<SpawnUnits>().spawnUnit2();
    }
}
