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

    // Start is called before the first frame update
    void Start()
    {
        if(target != null){
            maximum = target.maxLife;
        }
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
        float FillAmout = (float)current / (float)maximum;
        mask.fillAmount = FillAmout; //m_FillAmount
    }
    // void UpdatePose(){
    //     Vector3 dir = target.transform.position;
    //     dir.y += 2;
    //     float ms = target.moveSpeed;
    //     transform.Translate(dir.normalized * ms * Time.deltaTime, Space.World);
    // }
}
