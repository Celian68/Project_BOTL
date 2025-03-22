using UnityEngine;
using BOTL.Data;

public class SpellButton : AbstractButton {
    int spellIndex;

    public void SetSpell(SpellData spell, int index) {
        spellIndex = index;
        Debug.Log(spell);
        SetCost(spell.GetSpellStats(LevelManager._instance.GetLevelSpell(Team.Team1, spell)).baseCost);
        SetDescription(spell.Description);
        SetCooldown(spell.GetSpellStats(LevelManager._instance.GetLevelSpell(Team.Team1, spell)).cooldown);
    }

    public override void OnClick() {
        base.OnClick();
        Spell_Manager._instance.ActivateSpell(spellIndex);
    }
}