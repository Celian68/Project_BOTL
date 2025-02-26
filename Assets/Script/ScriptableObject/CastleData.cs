using UnityEngine;
using BOTL.Struct;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CastleData", menuName = "ScriptableObject/CastleData")]
public class CastleData : TargetData
{
    [SerializeField] List<CastleStats> castleStats;
    [SerializeField] List<ProduceurStats> produceurStats;

    public CastleStats GetCastleStats(int level)
    {
        return castleStats[level];
    }
    public ProduceurStats GetProduceurStats(int level)
    {
        return produceurStats[level];
    }
}
