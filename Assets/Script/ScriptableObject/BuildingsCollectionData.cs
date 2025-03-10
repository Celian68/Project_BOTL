using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingsCollectionData", menuName = "ScriptableObject/BuildingsCollectionData")]
public class BuildingsCollectionData : ScriptableObject
{
    [SerializeField] List<BuildingData> _humanData = new List<BuildingData>();
    [SerializeField] List<BuildingData> _elfData = new List<BuildingData>();
    [SerializeField] List<BuildingData> _newLandData = new List<BuildingData>();
    [SerializeField] CastleData _castleData;

    public BuildingData GetData(Faction faction, string unitID)
    {
        return faction switch
        {
            Faction.Human => _humanData.Find(x => x.BuildId == unitID),
            Faction.Elven => _elfData.Find(x => x.BuildId == unitID),
            Faction.NewLand => _newLandData.Find(x => x.BuildId == unitID),
            _ => null,
        };
    }

    public List<BuildingData> GetDataList(Faction faction)
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
