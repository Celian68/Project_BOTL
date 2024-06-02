using UnityEditor.VersionControl;
using UnityEngine;

public class KeyBoradManager : MonoBehaviour
{

    public static KeyBoradManager _instance;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.V)) {
            bool res = InfoPopUpBehavior._instance.setActiv();
            if (res)
                MessagePopUpBehavior._instance.showPopUp("InfoPopUp Activé");
            else
                MessagePopUpBehavior._instance.showPopUp("InfoPopUp Désactivé");
        }

        if(Input.GetKeyDown(KeyCode.B)) {
            bool res = UI_Manager._instance.setActiv();
            if (res)
                MessagePopUpBehavior._instance.showPopUp("Affichage Nombres Indicateurs Activé");
            else
                MessagePopUpBehavior._instance.showPopUp("Affichage Nombres Indicateurs Désactivé");
        }
    }

}
