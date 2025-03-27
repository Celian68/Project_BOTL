using Assets.Script.AssetsScripts.Enum;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    bool gameOver;

    [SerializeField] Transform InGameUI;

    [SerializeField] GameObject castle1;
    [SerializeField] GameObject castle2;

    [SerializeField] GameObject hero_menu;


    float maximum1;
    float current1;
    float maximum2;
    float current2;

    [SerializeField] Image mask1;
    [SerializeField] Image mask2;
    [SerializeField] Image maskHero;
    [SerializeField] Image respawnCooldownUIHero;
    float currentRespawnCooldownHero = 0;
    float respawnCooldownHero;

    [SerializeField] Text damageTextPrefab;

    [SerializeField] Camera mainCamera;

    [SerializeField] bool activ;

    public static UI_Manager _instance;

    void Awake()
    {
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
        activ = true;
        castle1.SetActive(true);
        hero_menu.SetActive(true);
        respawnCooldownHero = LevelManager._instance.GetPlayerProgressionData(Team.Team1).HeroData.GetUnitStats(LevelManager._instance.GetLevelHero(Team.Team1)).spawnTime;
        respawnCooldownUIHero.fillAmount = 0;
    }

    void Update()
    {
        GetCurrentFill();
        HeroRespawnCooldown();
    }

    public bool SetActiv()
    {
        return activ = !activ;
    }

    void HeroRespawnCooldown()
    {
        if (currentRespawnCooldownHero > 0)
        {
            currentRespawnCooldownHero -= Time.deltaTime;
            respawnCooldownUIHero.fillAmount = currentRespawnCooldownHero / respawnCooldownHero;
        }
    }

    void GetCurrentFill()
    {
        if (castle1 != null)
        {
            current1 = castle1.GetComponent<Castle>().GetLife();
            maximum1 = castle1.GetComponent<Castle>().GetTargetStats().maxLife;
            float FillAmout = current1 / maximum1;
            mask1.fillAmount = FillAmout;
        }
        if (castle2 != null)
        {
            current2 = castle2.GetComponent<Castle>().GetLife();
            maximum2 = castle2.GetComponent<Castle>().GetTargetStats().maxLife;
            float FillAmout = current2 / maximum2;
            mask2.fillAmount = FillAmout;
        }
        if (current1 <= 0 || current2 <= 0)
        {
            gameOver = true;
        }

        if (!gameOver)
        {
            float currentLife = HeroController._instance.GetHero().GetComponent<Hero>().GetLife();
            float maximumLife = HeroController._instance.GetHero().GetComponent<Hero>().GetTargetStats().maxLife;
            float FillAmout = currentLife / maximumLife;
            maskHero.fillAmount = FillAmout;
            if (currentLife <= 0 && currentRespawnCooldownHero <= 0)
            {
                currentRespawnCooldownHero = respawnCooldownHero;
            }
        }
    }

    public void ShowNumberText(int damage, Vector3 position, float player, string sign)
    {
        if (activ)
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(position);
            RectTransform canvasRect = InGameUI.GetComponent<RectTransform>();

            // Convertir les coordonnées écran en coordonnées locales du canvas
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPosition, mainCamera, out Vector2 localPoint);

            // Créer le texte à une position locale correcte
            Text damageText = Instantiate(damageTextPrefab, InGameUI);
            damageText.rectTransform.anchoredPosition = localPoint;

            damageText.text = sign + damage;

            if (sign == "-")
                damageText.color = Color.red;
            else if (sign == "+")
                damageText.color = Color.green;

            // Animation
            iTween.ScaleFrom(damageText.gameObject, new Vector3(0, 0, 0), 3f); // agrandissement
            LeanTween.alphaText(damageText.rectTransform, 0, 1.5f); // fade out

            // Animation de déplacement
            Vector2 targetPos = localPoint + new Vector2(player != 0 ? 200f * (player * -1) : 0, 200f);
            LeanTween.moveLocal(damageText.rectTransform.gameObject, targetPos, 1.5f);

            Destroy(damageText.gameObject, 4f);
        }
    }

}
