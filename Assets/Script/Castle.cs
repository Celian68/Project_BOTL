using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float maxRessources;
    private float currentRessources;
    public float ressourcesPerSec;

    public float maxLife;
    public float currentLife;

    public int ennemyPlayer;

    private int level;

    public Text ressourcesCount;
    public Text lifeCount;

    private GameObject gameManager;

    public GameObject Arche;

    public Animator animCastle;


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
        if (level == 1 && looseRessources(100)) {
            level++;
            animCastle.SetInteger("Level", level);
            maxRessources = 250;
            ressourcesPerSec = 4;
            Arche.GetComponent<Arche>().levelUp();
            //maxLife = 800;
        }else if (level == 2 && looseRessources(250)) {
            level++;
            animCastle.SetInteger("Level", level);
            maxRessources = 500;
            ressourcesPerSec = 6;
            Arche.GetComponent<Arche>().levelUp();
            //maxLife = 1500;
        }
    }
}
