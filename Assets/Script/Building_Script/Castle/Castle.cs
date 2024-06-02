using UnityEngine;
using UnityEngine.UI;

// Class that take care of the Castle of each player
public class Castle : MonoBehaviour
{

    public float maxLife; // Float that represent the maximum number of life that the player can have
    float currentLife; // Float that represent the current number of life that the player have

    public bool player; // Int that represent the ennemy player (Player 1 or Player 2)

    int level; // Level of the Castle of the Player

    public Text lifeCount;

    public GameObject Arche;

    public Animator animCastle;

    public GameObject LevelUpButton;

    void Start() {

        currentLife = maxLife;

        updateLife();

        gameObject.SetActive(true);

        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        showDamaged();
    } 

    public float getLife() {
        return currentLife;
    }

    public int getLevel() {
        return level;
    }

    public void getDamaged(float damage) {

        currentLife -= damage;

        if (currentLife < 0) {
            currentLife = 0;
        }
        updateLife();
        UI_Manager._instance.ShowNumberText(Mathf.RoundToInt(damage), transform.position, 0, "-");
        if (currentLife <= 0) {
            GameOverManager._instance.setGameOver(true, !player);
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

    void updateLife() {
        lifeCount.text = currentLife.ToString();
    }

    public void levelUp() {
        float pourcent = currentLife * 100/maxLife;

        if (level == 1 && RessourceManager._instance.ConsumResources(100, player)) {
            level++;
            animCastle.SetInteger("Level", level);
            RessourceManager._instance.setMaxResources(250, player);
            RessourceManager._instance.setResourcePerSec(2, player);
            Arche.GetComponent<Arch>().levelUp();
            maxLife = 800;
            currentLife = Mathf.RoundToInt(maxLife * pourcent * 0.01f);
            updateLife();
        }else if (level == 2 && RessourceManager._instance.ConsumResources(250, player)) {
            level++;
            animCastle.SetInteger("Level", level);
            RessourceManager._instance.setMaxResources(500, player);
            RessourceManager._instance.setResourcePerSec(3, player);
            Arche.GetComponent<Arch>().levelUp();
            maxLife = 1500;
            currentLife = Mathf.RoundToInt(maxLife * pourcent * 0.01f);
            LevelUpButton.SetActive(false);
            updateLife();
        }
    }

    public float nextLevelUpCost() {
        if (level == 1) {
            return 100;
        }else if (level == 2) {
            return 250;
        }
        return 0;
    }
}
