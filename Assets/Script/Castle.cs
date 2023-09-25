using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public float maxRessources;
    private float currentRessources;
    public float ressourcesPerSec;

    public float maxLife;
    public float currentLife;

    public float armor = 0;

    public Sprite state1;
    public Sprite state2;
    public Sprite state3;
    public Sprite state4;

    private  SpriteRenderer spriteR;

    public Text ressourcesCount;
    public Text lifeCount;


    void Start() {

        currentLife = maxLife;

        currentRessources = maxRessources;

        spriteR = gameObject.GetComponent<SpriteRenderer>();

        InvokeRepeating("generateRessources", 0f, 1f); 

        updateLife();

    }

    // Update is called once per frame
    void Update()
    {
        showDamaged();

        updateRessources();
    } 

    public void getDamaged(float damage) {

        if(armor >= 0 && armor > damage){
            armor -= damage;
        }else{
            currentLife -= damage;
            currentLife += armor;
            armor = 0;

            if (currentLife < 0) {
                currentLife = 0;
            }
        }

        updateLife();

        if (currentLife <= 0) {
            Destroy(gameObject);
        }
    }

    void showDamaged() {

        if (currentLife > maxLife * 0.75f) {
            spriteR.sprite = state1;
        }else if (currentLife > maxLife * 0.5f) {
            spriteR.sprite = state2;
        }else if (currentLife > maxLife * 0.25f) {
            spriteR.sprite = state3;
        }else{
            spriteR.sprite = state4;
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
}
