using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode()]
public class progessBarCastle : MonoBehaviour
{

  public float maximum;
    public float current;

    public Image mask;

    public Castle castle;

    void Start()
    {
        maximum = castle.maxLife;
    }

    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill(){
        if (castle != null) {
            current = castle.currentLife;
            float FillAmout = current / maximum;
            mask.fillAmount = FillAmout;
        }
    }

}
