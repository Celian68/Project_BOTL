using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObject/UnitData")]
public class UnitData : TargetData
{
    [SerializeField] UnitType unitType;
    [SerializeField] UnitClass unitClass;
    [SerializeField] List<UnitStats> unitStats;

    public UnitType UnitType => unitType;
    public UnitClass UnitClass => unitClass;

    public UnitStats GetUnitStats(Level level)
    {
        return unitStats[(int)level];
    }

}
