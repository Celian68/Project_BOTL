using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObject/UnitData")]
public class UnitData : TargetData
{
    [SerializeField] UnitName unitName;
    [SerializeField] UnitType unitType;
    [SerializeField] UnitClass unitClass;
    [SerializeField] List<UnitStats> unitStats;

    public UnitName UnitName => unitName;
    public UnitType UnitType => unitType;
    public UnitClass UnitClass => unitClass;
    public UnitStats GetUnitStats(int level)
    {
        return unitStats[level];
    }
}
