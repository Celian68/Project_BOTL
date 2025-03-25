using BOTL.Data;

public class SpellButton : UIButton {
    int spellIndex;

    public void SetSpell(SpellData spell, int index) {
        spellIndex = index;
        SetCost(spell.GetSpellStats(LevelManager._instance.GetLevelSpell(Team.Team1, spell)).baseCost);
        SetDescription(spell.Description);
        SetCooldown(spell.GetSpellStats(LevelManager._instance.GetLevelSpell(Team.Team1, spell)).cooldown);
    }

    public override void OnClick() {
        if (!IsActive()) return;
        base.OnClick();
        Spell_Manager._instance.ActivateSpell(spellIndex);
    }
}