using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BOTL.Data;

public abstract class AbstractUnit : AbstractTarget<UnitData>
{
    protected Transform enemyTarget;
    protected List<Collider2D> enemiesInRange;
    protected UnitState unitState;
    [SerializeField] Rigidbody2D rb;
    DetectEnemy detectEnemy;


    protected override void Start()
    {
        detectEnemy = GetComponentInChildren<DetectEnemy>();
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
        teamMultipl = team == Team.Team1 ? 1 : -1;
        if (team == Team.Team2) gameObject.GetComponent<SpriteRenderer>().flipX = true;
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
        enemiesInRange = detectEnemy.EnemiesDetection();
        enemyTarget = enemiesInRange.Count > 0 ? enemiesInRange[0].transform : null;
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
                    enemyTarget.GetComponent<ItTarget>()?.GetDamaged(GetUnitStats().damage);
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
        detectEnemy.SetRotation(rotation);
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

    protected void SetUnitState(UnitState newState)
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

    // Not optimal but necessary because onClick doesn't work with enum
    public virtual void SetUnitState(int newState)
    {
        SetUnitState((UnitState)newState);
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

}
