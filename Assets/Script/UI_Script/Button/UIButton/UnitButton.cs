using UnityEngine;
using Assets.Script.AssetsScripts.Enum;

public class UnitButton : UIButton
{
    UnitData unit;
    [SerializeField] Team team;

    public void SetUnit(UnitData unit)
    {
        this.unit = unit;
        SetCost(unit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, unit)).baseCost);
        SetDescription(unit.Description);
    }

    public override void OnClick()
    {
        if (!IsActive()) return;
        base.OnClick();
        if (team == Team.Team1)
        {
            if (UnitWaitList._instance.AddUnit(unit)) StartCooldown();
        }
        else
        {
            if (RessourceManager._instance.ConsumResources(unit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team2, unit)).baseCost, Team.Team2))
            {
                if (Spawn_Manager._instance.Spawn_Unit(unit, team)) StartCooldown();
            }
        }
    }
}