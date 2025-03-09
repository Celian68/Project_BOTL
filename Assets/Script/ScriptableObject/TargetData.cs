using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TargetData", menuName = "ScriptableObject/TargetData")]
public abstract class TargetData : ScriptableObject
{
    [SerializeField] string targetId; 
    [SerializeField] string displayName; 
    [SerializeField] Faction faction;
    [SerializeField] TargetType targetType;
    [SerializeField] List<TargetStats> targetStats;

    public string TargetId => targetId;
    public string DisplayName => displayName;
    public Faction Faction => faction;
    public TargetType TargetType => targetType;

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

}

