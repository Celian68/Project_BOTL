using System.Collections;
using UnityEngine;
using Assets.Script.AssetsScripts.Enum;

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
        return LevelManager._instance.GetLevelUnit(team, data);
    }

    protected override IEnumerator Attack()
    {
        yield return base.Attack();
        SetUnitState(UnitState.Moving);
    }

    protected override void Die()
    {
        base.Die();
        GameObject prop = Instantiate(data.DeadProp, new Vector3(transform.position.x + 0.3f, transform.position.y, 1), Quaternion.identity);
        prop.GetComponent<SpriteRenderer>().flipX = gameObject.GetComponent<SpriteRenderer>().flipX;
        Destroy(gameObject);
    }

    protected void LevelUp(Team t, UnitData unitData, Level level)
    {
        if (team == t && unitData == data)
        {
            currentLife = Mathf.RoundToInt(GetTargetStats().maxLife * currentLife / GetSpecificTargetStats(GetLevel() - 1).maxLife);
            UpdateLife();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        LevelManager._instance.OnUnitLevelUp -= LevelUp;
    }

    protected override void UpdateLife()
    {
        Debug.Log("UpdateLife à implémenter sur les unités basiques");
    }
}
