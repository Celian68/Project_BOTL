using UnityEngine;
using UnityEngine.UI;

// Class that take care of the Castle of each player
public class Castle : MonoBehaviour
{
    public float maxRessources; // Float that represent the maximum number of ressources that the player can have
    public float currentRessources; // Float that represent the current number of ressources that the player have
    public float ressourcesPerSec; // Float that represent the current number of ressources that the player gain every second

    public float maxLife; // Float that represent the maximum number of life that the player can have
    public float currentLife; // Float that represent the current number of life that the player have

    public int ennemyPlayer; // Int that represent the ennemy player (Player 1 or Player 2)

    public int level; // Level of the Castle of the Player

    public Text ressourcesCount;
    public Text lifeCount;

    private GameObject gameManager;

    public GameObject Arche;

    public Animator animCastle;

    public GameObject LevelUpButton;


    void Start() {

        currentLife = maxLife;

        currentRessources = 0;

        InvokeRepeating("generateRessources", 0f, 1f); 

        updateLife();

        gameObject.SetActive(true);

        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        level = 1;

    }

    // Update is called once per frame
    void Update()
    {
        showDamaged();

        updateRessources();
    } 

    public void getDamaged(float damage) {

        currentLife -= damage;

        if (currentLife < 0) {
            currentLife = 0;
        }
        updateLife();
        gameManager.GetComponent<UI_Manager>().ShowDamageText(Mathf.RoundToInt(damage), transform.position, 0);
        if (currentLife <= 0) {
            gameManager.GetComponent<GameOverManager>().setGameOver(true, ennemyPlayer);
            gameObject.SetActive(false);
        }
    }

    void showDamaged() {
        if (currentLife > maxLife * 0.75f) {
            animCastle.SetInteger("State", 0);
        }else if (currentLife > maxLife * 0.5f) {
            animCastle.SetInteger("State", 1);
        }else if (currentLife > maxLife * 0.25f) {
            animCastle.SetInteger("State", 2);
        }else{
            animCastle.SetInteger("State", 3);
        }
    }

    void generateRessources() { 
        if (currentRessources < maxRessources) {
            currentRessources += ressourcesPerSec;
        }

        if (currentRessources > maxRessources) {
            currentRessources = maxRessources;
        }
    }

    void updateRessources() {
        ressourcesCount.text = currentRessources.ToString();

        if ((currentRessources >= 100 && level == 1) || (currentRessources >= 250 && level == 2)) {
            LevelUpButton.SetActive(true);
        }else {
            LevelUpButton.SetActive(false);
        }
    }

    void updateLife() {
        lifeCount.text = currentLife.ToString();
    }

    public bool looseRessources(float cost) {
        if (cost <= currentRessources) {
            currentRessources -= cost;
            return true;
        }
        return false;
    }

    public void levelUp() {
        float pourcent = currentLife * 100/maxLife;

        if (level == 1 && looseRessources(100)) {
            level++;
            animCastle.SetInteger("Level", level);
            maxRessources = 250;
            ressourcesPerSec = 4;
            Arche.GetComponent<Arch>().levelUp();
            maxLife = 800;
            currentLife = Mathf.RoundToInt(maxLife * pourcent * 0.01f);
            updateLife();
        }else if (level == 2 && looseRessources(250)) {
            level++;
            animCastle.SetInteger("Level", level);
            maxRessources = 500;
            ressourcesPerSec = 6;
            Arche.GetComponent<Arch>().levelUp();
            maxLife = 1500;
            currentLife = Mathf.RoundToInt(maxLife * pourcent * 0.01f);
            updateLife();
        }
    }
}
