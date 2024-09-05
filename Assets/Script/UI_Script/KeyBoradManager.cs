using UnityEngine;

public class KeyBoradManager : MonoBehaviour
{

    public static KeyBoradManager _instance;

    public KeyCode infoPopUp;
    public KeyCode damageIndicators;

    public KeyCode spawnAlly1;
    public KeyCode spawnAlly2;
    public KeyCode spawnAlly3;
    public KeyCode spawnAlly4;
    public KeyCode spawnAlly5;

    public KeyCode spawnEnnemy1;
    public KeyCode spawnEnnemy2;
    public KeyCode spawnEnnemy3;
    public KeyCode spawnEnnemy4;
    public KeyCode spawnEnnemy5;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    void Start() {
        infoPopUp = KeyCode.V;
        damageIndicators = KeyCode.B;
        spawnAlly1 = KeyCode.Alpha1;
        spawnAlly2 = KeyCode.Alpha2;
        spawnAlly3 = KeyCode.Alpha3;
        spawnAlly4 = KeyCode.Alpha4;
        spawnAlly5 = KeyCode.Alpha5;
        spawnEnnemy1 = KeyCode.Alpha6;
        spawnEnnemy2 = KeyCode.Alpha7;
        spawnEnnemy3 = KeyCode.Alpha8;
        spawnEnnemy4 = KeyCode.Alpha9;
        spawnEnnemy5 = KeyCode.Alpha0;
    }

    void Update() {

        if(Input.GetKeyDown(infoPopUp)) {
            bool res = InfoPopUpBehavior._instance.setActiv();
            if (res)
                MessagePopUpBehavior._instance.showPopUp("InfoPopUp Activé");
            else
                MessagePopUpBehavior._instance.showPopUp("InfoPopUp Désactivé");
        }

        if(Input.GetKeyDown(damageIndicators)) {
            bool res = UI_Manager._instance.setActiv();
            if (res)
                MessagePopUpBehavior._instance.showPopUp("Affichage Nombres Indicateurs Activé");
            else
                MessagePopUpBehavior._instance.showPopUp("Affichage Nombres Indicateurs Désactivé");
        }

        if(Input.GetKeyDown(spawnAlly1)) {
            Spawn_Manager._instance.UnitButton1();
        }

        if(Input.GetKeyDown(spawnAlly2)) {
            Spawn_Manager._instance.UnitButton2();
        }

        if(Input.GetKeyDown(spawnAlly3)) {
            Spawn_Manager._instance.UnitButton3();
        }

        if(Input.GetKeyDown(spawnAlly4)) {
            
        }

        if(Input.GetKeyDown(spawnAlly5)) {
            
        }

        if(Input.GetKeyDown(spawnEnnemy1)) {
            Spawn_Manager._instance.UnitButton6();
        }

        if(Input.GetKeyDown(spawnEnnemy2)) {
            Spawn_Manager._instance.UnitButton7();
        }

        if(Input.GetKeyDown(spawnEnnemy3)) {
            Spawn_Manager._instance.UnitButton8();
        }

        if(Input.GetKeyDown(spawnEnnemy4)) {
            
        }

        if(Input.GetKeyDown(spawnEnnemy5)) {
            
        }
    }

}
