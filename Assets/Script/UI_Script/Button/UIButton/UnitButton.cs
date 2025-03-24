using UnityEngine;
using BOTL.Data;

public class UnitButton : UIButton {
    int unitIndex;
    [SerializeField] Team team;

    public void SetUnit(UnitData unit, int index) {
        unitIndex = index;
        SetCost(unit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, unit)).baseCost);
        SetDescription(unit.Description);
        SetCooldown(0.1f);
    }

    public override void OnClick() {
        base.OnClick();
        Spawn_Manager._instance.Spawn_Unit(unitIndex, team);
    }
}