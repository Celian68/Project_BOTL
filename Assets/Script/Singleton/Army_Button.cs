using System.Collections.Generic;
using BOTL.Data;
using UnityEngine;

public class Army_Button : MonoBehaviour
{
    public static Army_Button _instance;
    [SerializeField] List<GameObject> unitButtonsTeam1;
    [SerializeField] List<GameObject> unitButtonsTeam2; // Temporaire
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

    public void SetUnits(List<UnitData> data, Team team) {
        int index = 0;
        List<GameObject> unitButtons;
        if (team == Team.Team1) {
            unitButtons = unitButtonsTeam1;
        } else {
            unitButtons = unitButtonsTeam2;
        }
        foreach(UnitData unit in data) {
            unitButtons[index].GetComponent<UnitButton>().SetUnit(unit);
            index++;
        }
    }

    public void SetSpells(List<SpellData> data) {
        int index = 0;
        foreach(SpellData spell in data) {
            spellButtons[index].GetComponent<SpellButton>().SetSpell(spell, index);
            index++;
        }
    }

    public void StartSpellCooldown(int index) {
        spellButtons[index].GetComponent<SpellButton>().StartCooldown();
    }

}