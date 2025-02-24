using UnityEngine;
using BOTL.Enum;
using BOTL.Struct;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TargetData", menuName = "ScriptableObject/TargetData")]
public abstract class TargetData : ScriptableObject
{
    [SerializeField] Faction faction;
    [SerializeField] TargetType targetType;
    [SerializeField] List<TargetStats> targetStats;

    public Faction Faction => faction;
    public TargetType TargetType => targetType;
    public TargetStats GetTargetStats(int level)
    {
        return targetStats[level];
    }
}

