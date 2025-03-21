using System.Collections.Generic;
using UnityEngine;

public class Army_Button : MonoBehaviour
{
    public static Army_Button _instance;
    [SerializeField] List<GameObject> unitButtons;
    [SerializeField] List<GameObject> spellButtons;

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

    public void SetUnit() {}

}