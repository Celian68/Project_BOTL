using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]
public class progessBar : MonoBehaviour
{

    public float maximum;
    public float current;

    public Image mask;

    public Castle target;
    public UnitBehavior unit;

    // Start is called before the first frame update
    void Start()
    {
        if((target != null) && (unit == null)) { //changer
            maximum = target.maxLife;
        }
        //(target == null) && (unit != null)
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill(){
        if(target != null){
            current = target.currentLife;
        }
        mask.fillAmount = current / maximum;
    }

}
