using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    private bool gameOver;

    public Transform InGameUI;

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

    private float maximum1;
    private float current1;
    private float maximum2;
    private float current2;

    public Image mask1;
    public Image mask2;

    public Text damageTextPrefab;

    public Camera mainCamera;

    void Start() {
        castle1 = GameObject.FindGameObjectWithTag("Castle1");
        castle2 = GameObject.FindGameObjectWithTag("Castle2");
        spawn1 = GameObject.FindGameObjectWithTag("Spawn1").transform;
        spawn2 = GameObject.FindGameObjectWithTag("Spawn2").transform;
    }

    // Update is called once per frame
    void Update() {
        spawnUnits();
        GetCurrentFill();
        
    }

    void spawnUnits() {
        if (!gameOver) {
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
        
    }

    public void UnitButton1() {
        if (castle1.GetComponent<Castle>().looseRessources(unite1.GetComponent<UnitBehavior>().cost)) {
            spawn_Unit(unite1, spawn1);
        }
    }

    public void UnitButton2() {
        if (castle1.GetComponent<Castle>().looseRessources(unite2.GetComponent<UnitBehavior>().cost)) {
            spawn_Unit(unite2, spawn1);
        }
    }

    public void UnitButton3() {
        if (castle2.GetComponent<Castle>().looseRessources(unite6.GetComponent<UnitBehavior>().cost)) {
            spawn_Unit(unite6, spawn2);
        }
    }

    public void UnitButton4() {
        if (castle2.GetComponent<Castle>().looseRessources(unite7.GetComponent<UnitBehavior>().cost)) {
            spawn_Unit(unite7, spawn2);
        }
    }

    void GetCurrentFill(){
        if (castle1 != null) {
            current1 = castle1.GetComponent<Castle>().currentLife;
            maximum1 = castle1.GetComponent<Castle>().maxLife;
            float FillAmout = current1 / maximum1;
            mask1.fillAmount = FillAmout;
        }
        if (castle2 != null) {
            current2 = castle2.GetComponent<Castle>().currentLife;
            maximum2 = castle2.GetComponent<Castle>().maxLife;
            float FillAmout = current2 / maximum2;
            mask2.fillAmount = FillAmout;
        }
        if (current1 <= 0 || current2 <= 0) {
            gameOver = true;
        }
    }

    public void ShowDamageText(int damage, Vector3 position, float player) {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(position);
        Text damageText = Instantiate(damageTextPrefab, screenPosition, Quaternion.identity, InGameUI);
        damageText.text = "-" + damage;

        RectTransform canvasRect = InGameUI.GetComponent<RectTransform>();
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPosition, mainCamera, out canvasPos);

        Vector3 originalPosition = damageText.rectTransform.position;

        iTween.ScaleFrom(damageText.gameObject, new Vector3(0, 0, 0), 3f); // Agrandir le texte
        LeanTween.alphaText(damageText.rectTransform, 0, 1.5f); // Faire disparaître le texte
        
        
        LeanTween.moveLocalY(damageText.rectTransform.gameObject, originalPosition.y + canvasPos.y + 200f, 1.5f);
        if (player != 0) {
            LeanTween.moveLocalX(damageText.rectTransform.gameObject, originalPosition.x + canvasPos.x + 200f * (player * -1), 1.5f);
        }
        


        Destroy(damageText.gameObject, 4f);
    }

    public void spawn_Unit(GameObject unit, Transform spawn) {
        float randomNumber = Random.Range(23, 65)/100f;
        spawn.position = new Vector3(spawn.position.x, randomNumber, 0);
        Instantiate(unit, spawn.position, Quaternion.identity);   
    }
}
