using UnityEngine;

public class Castle : MonoBehaviour
{

    public float life = 500;

    public float armor = 0;

    // Update is called once per frame
    void Update()
    {
        
    } 

    void getDamaged(float damage) {
        if(armor >= 0 && armor > damage){
            armor -= damage;
        }else{
            life -= damage;
            life += armor;
            armor = 0;
        }

        if (life <= 0) {
            Destroy(gameObject);
        }
    }
}
