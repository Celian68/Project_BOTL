using UnityEngine;
using Assets.Script.AssetsScripts.Enum;
using Assets.Script.AssetsScripts.Struct;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObject/UnitData")]
public class UnitData : TargetData
{
    [SerializeField] UnitType unitType;
    [SerializeField] UnitClass unitClass;
    [SerializeField] Sprite icon;
    [SerializeField] GameObject deadProp;
    [SerializeField] List<UnitStats> unitStats;

    public UnitType UnitType => unitType;
    public UnitClass UnitClass => unitClass;
    public Sprite Icon => icon;
    public GameObject DeadProp => deadProp;

    public UnitStats GetUnitStats(Level level)
    {
        return unitStats[(int)level];
    }
}
