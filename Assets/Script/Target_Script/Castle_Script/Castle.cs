using UnityEngine;
using UnityEngine.UI;
using BOTL.Data;

// Class that take care of the Castle of each player
public class Castle : AbstractTarget<CastleData>
{
    [SerializeField] Text lifeCount;
    [SerializeField] GameObject Arch;

    protected BuildingState buildingState;
    
    protected override void Start()
    {
        base.Start();
        gameObject.SetActive(true);
        SetBuildingState(BuildingState.New);
        LevelManager._instance.OnCastleLevelUp += LevelUp;
    }

    protected override void SetupTeam()
    {
        base.SetupTeam();
        teamMultipl = 0;
        if (team == Team.Team2) transform.tag = "Castle2";
        else transform.tag = "Castle1";
    }

    protected override void UpdateLife()
    {
        lifeCount.text = currentLife.ToString();
        showDamaged();
    }

    void showDamaged()
    {
        if (currentLife > GetTargetStats().maxLife * 0.75f)
        {
            SetBuildingState(BuildingState.New);
        }
        else if (currentLife > GetTargetStats().maxLife * 0.5f)
        {
            SetBuildingState(BuildingState.Damaged);
        }
        else if (currentLife > GetTargetStats().maxLife * 0.25f)
        {
            SetBuildingState(BuildingState.Broken);
        }
        else
        {
            SetBuildingState(BuildingState.Destroyed);
        }
    }

    protected override void Die()
    {
        currentLife = 0;
        GameOverManager._instance.setGameOver(true, enemyTeam);
        gameObject.SetActive(false);
    }

    void SetBuildingState(BuildingState newState)
    {
        buildingState = newState;
        animator.SetInteger("BuildingState", (int)buildingState);
    }

    public override Level GetLevel()
    {
        return LevelManager._instance.getLevelCastle(team);
    }

    protected void LevelUp(Team t, Level newLevel)
    {
        if (team == t)
        {
            currentLife = Mathf.RoundToInt(GetTargetStats().maxLife * currentLife / GetSpecificTargetStats(GetLevel() - 1).maxLife);
            RessourceManager._instance.setMaxResources(500, team);
            RessourceManager._instance.setResourcePerSec(3, team);
            animator.SetInteger("Level", (int)GetLevel());
            Arch.GetComponent<Arch>().LevelUp((int)newLevel);
            UpdateLife();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        LevelManager._instance.OnCastleLevelUp -= LevelUp;
    }
}
