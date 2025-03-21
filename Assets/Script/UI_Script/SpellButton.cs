using BOTL.Data;

public class SpellButton : AbstractButton {
    int spellIndex;

    public void SetSpell(SpellData spell, int index) {
        spellIndex = index;
        SetCost(spell.GetUpgradeCost(LevelManager._instance.GetLevelSpell(Team.Team1, spell)));
        SetDescription(spell.DisplayName);
        SetCooldown(spell.GetSpellStats(LevelManager._instance.GetLevelSpell(Team.Team1, spell)).cooldown);
    }

    public override void OnClick() {
        base.OnClick();
        Spell_Manager._instance.ActivateSpell(spellIndex);
    }
}