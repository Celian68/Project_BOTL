using UnityEngine;

public class ButtonBuildings : MonoBehaviour
{

    public GameObject building;

    public GameObject menu;

    void Start() {
        gameObject.SetActive(true);
    }

    private void OnMouseDown() {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }

}
