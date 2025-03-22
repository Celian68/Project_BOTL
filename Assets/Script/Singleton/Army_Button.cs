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

    public void SetUnits(UnitData data, int index) {

    }

    public void SetSpells(List<SpellData> data) {
        int index = 0;
        foreach(SpellData spell in data) {
            spellButtons[index].GetComponent<SpellButton>().SetSpell(spell, index);
            index++;
        }
    }

}