using UnityEngine;
using Assets.Script.AssetsScripts.Enum;
using Assets.Script.AssetsScripts.Struct;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TargetData", menuName = "ScriptableObject/TargetData")]
public abstract class TargetData : ScriptableObject
{
    [SerializeField] string targetId;
    [SerializeField] string displayName;
    [SerializeField] Faction faction;
    [SerializeField] string description;
    [SerializeField] TargetType targetType;
    [SerializeField] GameObject targetPrefab;

    [SerializeField] List<TargetStats> targetStats;

    public string TargetId => targetId;
    public string DisplayName => displayName;
    public Faction Faction => faction;
    public string Description => description;
    public TargetType TargetType => targetType;
    public GameObject TargetPrefab => targetPrefab;

    public int GetUpgradeCost(Level currentLevel)
    {
        int idx = (int)currentLevel;
        if (idx < 0 || idx >= targetStats.Count - 1) return -1;
        return targetStats[idx].nextUpgradeCost;
    }

    public TargetStats GetTargetStats(Level level)
    {
        return targetStats[(int)level];
    }

    public void StartTrigger(TriggerType trigger, EffectContext context, Level level)
    {
        List<TriggerData> triggers = GetTargetStats(level).targetTriggers;
        foreach (TriggerData t in triggers)
        {
            t.ApplyEffects(context, trigger);
        }
    }

}

