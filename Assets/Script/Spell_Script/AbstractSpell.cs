using System.Collections.Generic;
using BOTL.Data;
using UnityEngine;

public abstract class AbstractSpell : MonoBehaviour
{
    [SerializeField] protected SpellData data;
    protected Team team = Team.Team1;

    protected void StartTrigger(TriggerType trigger, EffectContext context)
    {
        data.StartTrigger(trigger, context, GetLevel());
    }

    public Level GetLevel()
    {
        return LevelManager._instance.GetLevelSpell(team, data);
    }
}