using TMPro;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float maxRessources;
    private float currentRessources;

    public float maxLife;
    private float currentLife;

    public float armor = 0;

    public Sprite state1;
    public Sprite state2;
    public Sprite state3;
    public Sprite state4;

    private  SpriteRenderer spriteR;


    void Start() {
        currentLife = maxLife;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        showDamaged();
    } 

    public void getDamaged(float damage) {
        if(armor >= 0 && armor > damage){
            armor -= damage;
        }else{
            currentLife -= damage;
            currentLife += armor;
            armor = 0;
        }

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
}
