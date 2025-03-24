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
        LevelManager._instance.onCastleLevelUp += LevelUp;
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
        ShowDamaged();
    }

    void ShowDamaged()
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
        return LevelManager._instance.GetLevelCastle(team);
    }

    protected void LevelUp(Team t, Level newLevel)
    {
        if (team == t)
        {
            currentLife = Mathf.RoundToInt(GetTargetStats().maxLife * currentLife / GetSpecificTargetStats(GetLevel() - 1).maxLife);
            RessourceManager._instance.SetMaxResources(GetCastleStats().maxResource, team);
            RessourceManager._instance.SetResourcePerSec(GetProducerStats().resourcePerSec, team);
            animator.SetInteger("Level", (int)GetLevel());
            Arch.GetComponent<Arch>().LevelUp((int)newLevel);
            UpdateLife();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        LevelManager._instance.onCastleLevelUp -= LevelUp;
    }

    public CastleStats GetCastleStats()
    {
        return data.GetCastleStats(GetLevel());
    }

    public CastleStats GetSpecificCastleStats(Level level)
    {
        return data.GetCastleStats(level);
    }

    public ProducerStats GetProducerStats()
    {
        return data.GetProducerStats(GetLevel());
    }

    public ProducerStats GetSpecificProducerStats(Level level)
    {
        return data.GetProducerStats(level);
    }
}
