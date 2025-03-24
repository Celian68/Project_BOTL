using BOTL.Data;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public static HeroController _instance;
    GameObject hero;


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

    public GameObject GetHero()
    {
        return hero;
    }

    public void SetHero(GameObject hero) {
        this.hero = hero;
    }

    public void SetHeroOrder(UnitState order) {
        hero.GetComponent<Hero>().SetUnitState(order);
    }

}