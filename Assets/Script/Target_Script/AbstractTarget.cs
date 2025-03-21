using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

public abstract class AbstractTarget<Data> : MonoBehaviour, ItTarget where Data : TargetData
{
    [SerializeField] protected Data data;
    [SerializeField] protected Animator animator;
    protected float currentLife;
    protected Team enemyTeam;
    protected int teamMultipl;
    protected Team team;


    protected virtual void Start()
    {
        SetupTeam();
        currentLife = GetTargetStats().maxLife;
        UpdateLife();
        if (data == null)
        {
            Debug.LogError($" Erreur : `data` (UnitData) est NULL sur {gameObject.name} !");
        }
    }

    protected virtual void SetupTeam()
    {
        if (gameObject.transform.position.x < 0)
        {
            team = Team.Team1;
            enemyTeam = Team.Team2;
        }
        else
        {
            team = Team.Team2;
            enemyTeam = Team.Team1;
        }
    }

    public virtual void GetDamaged(float damage)
    {
        currentLife -= damage;
        UI_Manager._instance.ShowNumberText(Mathf.RoundToInt(damage), transform.position, teamMultipl, "-");
        UpdateLife();
        if (currentLife <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(float heal)
    {
        if (currentLife < GetTargetStats().maxLife) UI_Manager._instance.ShowNumberText(Mathf.RoundToInt(heal), transform.position, teamMultipl, "+"); ;
        currentLife = Mathf.Min(currentLife + heal, GetTargetStats().maxLife);
        UpdateLife();
    }

    public virtual void FullHeal() => Heal(GetTargetStats().maxLife);

    protected abstract void Die();

    protected abstract void UpdateLife();
    protected virtual void OnDestroy()
    { }

    public abstract Level GetLevel();

    public TargetStats GetTargetStats()
    {
        return data.GetTargetStats(GetLevel());
    }

    public TargetStats GetSpecificTargetStats(Level level)
    {
        return data.GetTargetStats(level);
    }

    public Team GetTeam()
    {
        return team;
    }

    public int GetTeamMultipl()
    {
        return teamMultipl;
    }

    public float GetLife()
    {
        return currentLife;
    }

    public int NextLevelUpCost()
    {
        return GetTargetStats().nextUpgradeCost;
    }

    protected void StartTrigger(TriggerType trigger, List<Transform> targets, Dictionary<EffectType, EffectBlob> blob = null)
    {
        data.StartTrigger(trigger, new EffectContext(transform, targets, blob), GetLevel());
    }
}
