using UnityEngine;
using Assets.Script.AssetsScripts.Enum;
using Assets.Script.AssetsScripts.Struct;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CastleData", menuName = "ScriptableObject/CastleData")]
public class CastleData : TargetData
{
    [SerializeField] List<CastleStats> castleStats;
    [SerializeField] List<ProducerStats> producerStats;

    public CastleStats GetCastleStats(Level level)
    {
        return castleStats[(int)level];
    }

    public ProducerStats GetProducerStats(Level level)
    {
        return producerStats[(int)level];
    }
}
