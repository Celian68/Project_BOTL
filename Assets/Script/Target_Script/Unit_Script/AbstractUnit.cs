using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BOTL.Data;

public abstract class AbstractUnit : AbstractTarget<UnitData>
{
    protected Transform enemyTarget;
    protected Transform allyTarget;
    protected List<Collider2D> enemiesInRange;
    protected List<Collider2D> alliesInRange;
    public UnitState unitState;
    [SerializeField] Rigidbody2D rb;
    DetectUnit detectUnit;


    protected override void Start()
    {
        detectUnit = GetComponentInChildren<DetectUnit>();
        base.Start();
        rb.excludeLayers = LayerMask.GetMask("Unit");
        InvokeRepeating(nameof(Behavior), 0f, 0.2f);
    }

    protected virtual void Update()
    {
        if (unitState == UnitState.Moving || unitState == UnitState.Retreating)
        {
            Move();
        }
    }

    protected override void SetupTeam()
    {
        base.SetupTeam();
        UpdateTeam();
    }

    protected virtual void UpdateTeam()
    {
        teamMultipl = team == Team.Team1 ? 1 : -1;
        gameObject.GetComponent<SpriteRenderer>().flipX = team == Team.Team2;
        transform.tag = team.ToString();
    }

    protected virtual void Behavior()
    {
        CheckEnemyInRange();
        if (CheckUnitPosition() && enemyTarget != null && CheckUnitState())
        {
            StartCoroutine(Attack());
        }
    }

    protected virtual void CheckEnemyInRange()
    {
        enemiesInRange = detectUnit.EnemiesDetection();
        enemyTarget = enemiesInRange.Count > 0 ? enemiesInRange[0].transform : null;
    }

    protected virtual void CheckAllyInRange()
    {
        alliesInRange = detectUnit.AlliesDetection();
        allyTarget = alliesInRange.Count > 0 ? alliesInRange[0].transform : null;
    }

    protected virtual bool CheckUnitPosition()
    {
        if (transform.position.x < -15f || transform.position.x > 45f || transform.position.y < -5f)
        {
            Die();
            return false;
        }
        return true;
    }

    protected virtual bool CheckUnitState()
    {
        if (unitState == UnitState.Idle || unitState == UnitState.Moving)
        {
            return true;
        }
        return false;
    }

    bool CheckEnemyState()
    {
        return enemyTarget != null && enemyTarget.gameObject.activeSelf && unitState != UnitState.Retreating && unitState != UnitState.CancelLoad;
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.right * teamMultipl * GetUnitStats().moveSpeed * Time.deltaTime, Space.World);
    }

    protected virtual IEnumerator Attack()
    {
        while (CheckEnemyState())
        {
            SetUnitState(UnitState.Charging);
            yield return new WaitForSeconds(GetUnitStats().attackSpeed);
            if (CheckEnemyState())
            {
                SetUnitState(UnitState.Attacking);
                yield return new WaitForSeconds(0.25f);
                if (CheckEnemyState())
                {
                    StartTrigger(TriggerType.OnHit, new EffectContext(new Dictionary<EffectType, AbstractEffectParam> {
                        { EffectType.Damage, new MonoEffectParam(-1, transform, new List<Transform> { enemyTarget }) }
                    }));
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
        SetUnitState(UnitState.CancelLoad);
    }

    protected override void Die()
    {
        currentLife = 0;
        UpdateLife();
        DeadUnitManager._instance.SpawnDeadUnit(transform.position);
    }

    protected void Rotate(float rotation)
    {
        detectUnit.SetRotation(rotation);
        rotation *= teamMultipl;
        if (rotation == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rotation == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public virtual void SetUnitState(UnitState newState)
    {
        unitState = newState;
        animator.SetInteger("UnitState", (int)unitState);
        if (newState == UnitState.Retreating)
        {
            Rotate(-1);
        }
        else
        {
            Rotate(1);
        }
    }

    public UnitClass GetUnitClass()
    {
        return data.UnitClass;
    }

    public UnitStats GetUnitStats()
    {
        return data.GetUnitStats(GetLevel());
    }

    public UnitStats GetSpecificUnitStats(Level level)
    {
        return data.GetUnitStats(level);
    }

    public void ChangeUnitTeam(Team newTeam)
    {
        team = newTeam;
        UpdateTeam();
    }

}
