using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]

public class progessBarUnit : MonoBehaviour
{

  public float maximum;
    public float current;

    public Image mask;

    public UnitBehavior unit;

    // Start is called before the first frame update
    void Start()
    {
     maximum = unit.life;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        transform.position = unit.transform.position;
    }

    void GetCurrentFill(){
            current = unit.life;
        float FillAmout = (float)current / (float)maximum;
        mask.fillAmount = FillAmout; //m_FillAmount
    }

}
