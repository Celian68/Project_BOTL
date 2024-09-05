using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    bool gameOver;

    public Transform InGameUI;

    GameObject castle1;
    GameObject castle2;
    public GameObject hero1;

    public GameObject hero_menu;

    float maximum1;
    float current1;
    float maximum2;
    float current2;

    public Image mask1;
    public Image mask2;
    public Image maskHero;

    public Text damageTextPrefab;

    public Camera mainCamera;

    public bool activ;

    public static UI_Manager _instance;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    void Start() {
        castle1 = GameObject.FindGameObjectWithTag("Castle1");
        castle2 = GameObject.FindGameObjectWithTag("Castle2");
        activ = true;
        castle1.SetActive(true);
        hero_menu.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
        GetCurrentFill();    
    }

    public bool setActiv() {
        return activ = !activ;
    }

    void GetCurrentFill(){
        if (castle1 != null) {
            current1 = castle1.GetComponent<Castle>().getLife();
            maximum1 = castle1.GetComponent<Castle>().maxLife;
            float FillAmout = current1 / maximum1;
            mask1.fillAmount = FillAmout;
        }
        if (castle2 != null) {
            current2 = castle2.GetComponent<Castle>().getLife();
            maximum2 = castle2.GetComponent<Castle>().maxLife;
            float FillAmout = current2 / maximum2;
            mask2.fillAmount = FillAmout;
        }
        if (current1 <= 0 || current2 <= 0) {
            gameOver = true;
        }

        if (!gameOver) {
            float currentLife = hero1.GetComponent<HeroBehavior>().getLife();
            float maximumLife = hero1.GetComponent<HeroBehavior>().maxLife;
            float FillAmout = currentLife / maximumLife;
            maskHero.fillAmount = FillAmout;
        }
    }

    public void ShowNumberText(int damage, Vector3 position, float player, string sign) {
        if (activ) {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(position);
            Text damageText = Instantiate(damageTextPrefab, screenPosition, Quaternion.identity, InGameUI);
            damageText.text = sign + damage;

            if (sign == "-") {
                damageText.color = Color.red;
            }else if (sign == "+") {
                damageText.color = Color.green;
            }

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
        
    }
}
