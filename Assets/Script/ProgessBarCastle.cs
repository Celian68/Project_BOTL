using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]
public class progessBarCastle : MonoBehaviour
{

  public float maximum;
    public float current;

    public Image mask;

    public Castle castle;

    // Start is called before the first frame update
    void Start()
    {
     maximum = castle.maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill(){
        current = castle.currentLife;
        float FillAmout = (float)current / (float)maximum;
        mask.fillAmount = FillAmout; //m_FillAmount
    }

}
