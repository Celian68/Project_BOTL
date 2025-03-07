using UnityEngine;
using UnityEngine.UI;
using BOTL.Data;
using System.Collections;


public class Hero : AbstractUnit
{
    UnitState command;

    [SerializeField] Text lifeCount;
    [SerializeField] Transform respawn;

    protected override void Start()
    {
        base.Start();
        SetUnitState(UnitState.Idle);
        LevelManager._instance.OnHeroLevelUp += LevelUp;
    }

    protected override void SetupTeam()
    {
        base.SetupTeam();
        if (team == Team.Team1)
        {
            respawn = GameObject.Find("Spawn1").transform;
        }
        else
        {
            respawn = GameObject.Find("Spawn2").transform;
        }
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
        transform.position = new Vector3(respawn.position.x, 0.7f, 0);
        Invoke("Respawn", 10f);
    }

    void Respawn()
    {
        gameObject.SetActive(true);
        FullHeal();
        UpdateLife();
        SetUnitState(UnitState.Idle);
    }

    public override void SetUnitState(int newState)
    {
        base.SetUnitState(newState);
        command = (UnitState)newState;
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
