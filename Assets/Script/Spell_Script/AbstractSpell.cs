using System.Collections.Generic;
using BOTL.Data;
using UnityEngine;

public abstract class AbstractSpell : MonoBehaviour
{
    [SerializeField] protected SpellData data;
    protected Team team = Team.Team1;

    protected void StartTrigger(TriggerType trigger, List<Transform> targets, Dictionary<EffectType, EffectBlob> blob = null)
    {
        data.StartTrigger(trigger, new EffectContext(transform, targets, blob), GetLevel());
    }

    public Level GetLevel()
    {
        return LevelManager._instance.getLevelSpell(team, data);
    }
}