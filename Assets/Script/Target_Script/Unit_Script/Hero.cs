using UnityEngine;
using BOTL.Data;
using System.Collections;


public class Hero : AbstractUnit
{
    UnitState command;


    protected override void Start()
    {
        base.Start();
        SetUnitState(UnitState.Idle);
        LevelManager._instance.OnHeroLevelUp += LevelUp;
    }

    protected override void SetupTeam()
    {
        base.SetupTeam();
    }

    protected override void Move()
    {
        if (unitState == UnitState.Retreating)
        {
            Vector3 tar = new(teamMultipl, 0, 0);
            tar *= -1;
            transform.Translate(GetUnitStats().moveSpeed * Time.deltaTime * tar.normalized, Space.World);
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
        HeroController._instance.updateHeroLife(currentLife);
    }

    protected override void Die()
    {
        base.Die();
        gameObject.SetActive(false);
        transform.position = new Vector3(Spawn_Manager._instance.getSpawn(team).position.x, 0.7f, 0);
        Invoke(nameof(Respawn), GetUnitStats().spawnTime);
    }

    void Respawn()
    {
        gameObject.SetActive(true);
        FullHeal();
        UpdateLife();
        SetUnitState(UnitState.Idle);
    }

    public void SetOrderUnitState(UnitState newState)
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
        LevelManager._instance.OnHeroLevelUp -= LevelUp;
    }
}
