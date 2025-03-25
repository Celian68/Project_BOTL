using UnityEngine;
using BOTL.Data;

public class LevelUpCastleButton : UIButton {
    [SerializeField] Team team;

    protected override void Start()
    {
        base.Start();
        gameObject.SetActive(true);
        CastleData data = LevelManager._instance.GetPlayerProgressionData(team).CastleData;
        SetDescription(data.Description);
        SetCost(data.GetUpgradeCost(LevelManager._instance.GetLevelCastle(team)));
        SetCooldown(0.3f);
    }

    public override void OnClick() {
        if (!IsActive()) return;
        base.OnClick();
        StartCooldown();
        LevelManager._instance.LevelUpCastle(team);
        if (LevelManager._instance.GetLevelCastle(team) == Level.Level3)
        {
            gameObject.SetActive(false);
        }
        SetCost(LevelManager._instance.GetPlayerProgressionData(team).CastleData.GetUpgradeCost(LevelManager._instance.GetLevelCastle(team)));
    }
}