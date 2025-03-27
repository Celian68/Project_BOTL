using UnityEngine;
using Assets.Script.AssetsScripts.Enum;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UnitsCollectionData", menuName = "ScriptableObject/UnitsCollectionData")]
public class UnitsCollectionData : ScriptableObject
{
    [SerializeField] List<UnitData> _humanData = new();
    [SerializeField] List<UnitData> _elfData = new();
    [SerializeField] List<UnitData> _newLandData = new();

    public UnitData GetData(Faction faction, string unitID)
    {
        return faction switch
        {
            Faction.Human => _humanData.Find(x => x.TargetId == unitID),
            Faction.Elven => _elfData.Find(x => x.TargetId == unitID),
            Faction.NewLand => _newLandData.Find(x => x.TargetId == unitID),
            _ => null,
        };
    }

    public List<UnitData> GetDataList(Faction faction)
    {
        return faction switch
        {
            Faction.Human => _humanData,
            Faction.Elven => _elfData,
            Faction.NewLand => _newLandData,
            _ => null,
        };
    }
}
