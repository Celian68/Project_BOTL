using UnityEngine;
using BOTL.Data;

public class UnitButton : UIButton {
    int unitIndex;
    [SerializeField] Team team;

    public void SetUnit(UnitData unit, int index) {
        unitIndex = index;
        SetCost(unit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, unit)).baseCost);
        SetDescription(unit.Description);
        SetCooldown(0.3f);
    }

    public override void OnClick() {
        if (!IsActive()) return;
        base.OnClick();
        StartCooldown();
        Spawn_Manager._instance.Spawn_Unit(unitIndex, team);
    }
}