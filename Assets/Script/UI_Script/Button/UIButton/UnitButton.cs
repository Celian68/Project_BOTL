using UnityEngine;
using BOTL.Data;

public class UnitButton : UIButton {
    UnitData unit;
    [SerializeField] Team team;

    public void SetUnit(UnitData unit) {
        this.unit = unit;
        SetCost(unit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, unit)).baseCost);
        SetDescription(unit.Description);
    }

    public override void OnClick() {
        if (!IsActive()) return;
        base.OnClick();
        if (UnitWaitList._instance.AddUnit(unit)) StartCooldown();
    }
}