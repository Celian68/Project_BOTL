using Assets.Script.AssetsScripts.Enum;
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

    public KeyCode spawnEnemy1;
    public KeyCode spawnEnemy2;
    public KeyCode spawnEnemy3;
    public KeyCode spawnEnemy4;
    public KeyCode spawnEnemy5;

    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        infoPopUp = KeyCode.V;
        damageIndicators = KeyCode.B;
        spawnAlly1 = KeyCode.Alpha1;
        spawnAlly2 = KeyCode.Alpha2;
        spawnAlly3 = KeyCode.Alpha3;
        spawnAlly4 = KeyCode.Alpha4;
        spawnAlly5 = KeyCode.Alpha5;
        spawnEnemy1 = KeyCode.Alpha6;
        spawnEnemy2 = KeyCode.Alpha7;
        spawnEnemy3 = KeyCode.Alpha8;
        spawnEnemy4 = KeyCode.Alpha9;
        spawnEnemy5 = KeyCode.Alpha0;
    }

    void Update()
    {

        if (Input.GetKeyDown(infoPopUp))
        {
            bool res = InfoPopUpBehavior._instance.SetActiv();
            if (res)
                MessagePopUpBehavior._instance.ShowPopUp("InfoPopUp Activé");
            else
                MessagePopUpBehavior._instance.ShowPopUp("InfoPopUp Désactivé");
        }

        if (Input.GetKeyDown(damageIndicators))
        {
            bool res = UI_Manager._instance.SetActiv();
            if (res)
                MessagePopUpBehavior._instance.ShowPopUp("Affichage Nombres Indicateurs Activé");
            else
                MessagePopUpBehavior._instance.ShowPopUp("Affichage Nombres Indicateurs Désactivé");
        }

        if (Input.GetKeyDown(spawnAlly1))
        {
            Spawn_Manager._instance.Spawn_Unit(0, Team.Team1);
        }

        if (Input.GetKeyDown(spawnAlly2))
        {
            Spawn_Manager._instance.Spawn_Unit(1, Team.Team1);
        }

        if (Input.GetKeyDown(spawnAlly3))
        {

        }

        if (Input.GetKeyDown(spawnAlly4))
        {

        }

        if (Input.GetKeyDown(spawnAlly5))
        {

        }

        if (Input.GetKeyDown(spawnEnemy1))
        {
            Spawn_Manager._instance.Spawn_Unit(0, Team.Team2);
        }

        if (Input.GetKeyDown(spawnEnemy2))
        {
            Spawn_Manager._instance.Spawn_Unit(1, Team.Team2);
        }

        if (Input.GetKeyDown(spawnEnemy3))
        {

        }

        if (Input.GetKeyDown(spawnEnemy4))
        {

        }

        if (Input.GetKeyDown(spawnEnemy5))
        {

        }
    }

}
