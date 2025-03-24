using UnityEngine;
using BOTL.Data;

public class HeroOrderButton : AbstractButton {
    [SerializeField] UnitState order;
    [SerializeField] string descriptionState;

    void Start()
    {
        gameObject.SetActive(true);
        SetDescription(descriptionState);
        SetCost(-1);
        SetCooldown(0.1f);
    }

    public override void OnClick() {
        base.OnClick();
        Debug.Log(LevelManager._instance.GetPlayerProgressionData(Team.Team1).HeroData);
        Debug.Log(LevelManager._instance.GetPlayerProgressionData(Team.Team1).HeroData.TargetPrefab);
        Debug.Log(LevelManager._instance.GetPlayerProgressionData(Team.Team1).HeroData.TargetPrefab.GetComponent<Hero>());
        LevelManager._instance.GetPlayerProgressionData(Team.Team1).HeroData.TargetPrefab.GetComponent<Hero>().SetUnitState(order);
    }
}