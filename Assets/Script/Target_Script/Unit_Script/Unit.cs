using System.Collections;
using UnityEngine;
using BOTL.Enum;

public class Unit : AbstractUnit
{
    protected override void Start()
    {
        base.Start();
        SetUnitState(UnitState.Moving);
        LevelManager._instance.OnUnitLevelUp += LevelUp;
    }
    
    public override Level GetLevel()
    {
        return LevelManager._instance.getLevelUnit(team, data.UnitName);
    }

    protected override IEnumerator Attack()
    {
        yield return base.Attack();
        SetUnitState(UnitState.Moving);
    }
    
    protected override void Die()
    {
        transform.position = new Vector3(transform.position.x, (float)(transform.position.y + 0.16), 0);
        base.Die();
        Destroy(gameObject);
    }

    protected void LevelUp(Team t, UnitName unitName, Level level)
    {
        if (team == t && unitName == data.UnitName)
        {
            currentLife = Mathf.RoundToInt(GetTargetStats().maxLife * currentLife/ GetTargetStats().maxLife);
            UpdateLife();
        }
    }

    protected override void OnDestroy()
    {
        LevelManager._instance.OnUnitLevelUp -= LevelUp;
    }

    protected override void UpdateLife()
    {
        Debug.Log("UpdateLife à implémenter sur les unités basiques");
    }
}
