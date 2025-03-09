using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "UnitsCollectionData", menuName = "ScriptableObject/UnitsCollectionData")]
public class UnitsCollectionData : ScriptableObject
{
    [SerializeField] List<UnitData> _humanData = new List<UnitData>();
    [SerializeField] List<UnitData> _elfData = new List<UnitData>();
    [SerializeField] List<UnitData> _newLandData = new List<UnitData>();
    [SerializeField] CastleData _castleData;

    public UnitData GetUnitData(Faction faction, string unitID)
    {
        return faction switch
        {
            Faction.Human => _humanData.Find(x => x.TargetId == unitID),
            Faction.Elven => _elfData.Find(x => x.TargetId == unitID),
            Faction.NewLand => _newLandData.Find(x => x.TargetId == unitID),
            _ => null,
        };
    }

    public List<UnitData> GetUnitDataList(Faction faction)
    {
        return faction switch
        {
            Faction.Human => _humanData,
            Faction.Elven => _elfData,
            Faction.NewLand => _newLandData,
            _ => null,
        };
    }

    public CastleData GetCastleData()
    {
        return _castleData;
    }
}
