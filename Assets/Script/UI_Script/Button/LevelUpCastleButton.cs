using UnityEngine;
using BOTL.Data;

public class LevelUpCastleButton : AbstractButton {
    [SerializeField] Team team;

    void Start()
    {
        gameObject.SetActive(true);
        CastleData data = LevelManager._instance.GetPlayerProgressionData(team).CastleData;
        SetDescription(data.Description);
        SetCost(data.GetUpgradeCost(LevelManager._instance.GetLevelCastle(team)));
        SetCooldown(0.1f);
    }

    public override void OnClick() {
        base.OnClick();
        LevelManager._instance.LevelUpCastle(team);
        if (LevelManager._instance.GetLevelCastle(team) == Level.Level3)
        {
            gameObject.SetActive(false);
        }
        SetCost(LevelManager._instance.GetPlayerProgressionData(team).CastleData.GetUpgradeCost(LevelManager._instance.GetLevelCastle(team)));
    }
}