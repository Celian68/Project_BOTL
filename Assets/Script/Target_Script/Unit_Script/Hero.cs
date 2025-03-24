using UnityEngine;
using UnityEngine.UI;
using BOTL.Data;
using System.Collections;


public class Hero : AbstractUnit
{
    UnitState command;

    [SerializeField] Text lifeCount;

    protected override void Start()
    {
        base.Start();
        SetUnitState(UnitState.Idle);
        LevelManager._instance.onHeroLevelUp += LevelUp;
    }

    protected override void SetupTeam()
    {
        base.SetupTeam();
    }

    protected override void Move()
    {
        if (unitState == UnitState.Retreating)
        {
            Vector3 tar = new Vector3(teamMultipl, 0, 0);
            tar *= -1;
            transform.Translate(tar.normalized * GetUnitStats().moveSpeed * Time.deltaTime, Space.World);
            if (transform.position.x < -13f)
            {
                SetUnitState(UnitState.Idle);
            }
        }
        else
        {
            base.Move();
        }
    }

    protected override IEnumerator Attack()
    {
        yield return base.Attack();
        SetUnitState(command);
    }

    protected override void UpdateLife()
    {
        lifeCount.text = currentLife.ToString();
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
        transform.position = new Vector3(Spawn_Manager._instance.getSpawn(team).position.x, 0.7f, 0);
        Invoke("Respawn", GetUnitStats().spawnTime);
    }

    void Respawn()
    {
        gameObject.SetActive(true);
        FullHeal();
        UpdateLife();
        SetUnitState(UnitState.Idle);
    }

    public override void SetUnitState(UnitState newState)
    {
        command = newState;

        if (newState == UnitState.Retreating && unitState == UnitState.Charging) {
            base.SetUnitState(UnitState.CancelLoad);
            return;
        }
        if (unitState != UnitState.Attacking && unitState != UnitState.Charging)
        {
            base.SetUnitState(newState);
        }
        
    }

    public override Level GetLevel()
    {
        return LevelManager._instance.getLevelHero(team);
    }

    private void LevelUp(Team t, Level newLevel)
    {
        if (team == t)
        {
            currentLife = Mathf.RoundToInt(GetTargetStats().maxLife * currentLife / GetSpecificTargetStats(GetLevel() - 1).maxLife);
            UpdateLife();
        }
    }

    protected override void OnDestroy()
    {
        LevelManager._instance.onHeroLevelUp -= LevelUp;
    }
}
