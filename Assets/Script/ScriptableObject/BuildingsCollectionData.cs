using UnityEngine;
using Assets.Script.AssetsScripts.Enum;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingsCollectionData", menuName = "ScriptableObject/BuildingsCollectionData")]
public class BuildingsCollectionData : ScriptableObject
{
    [SerializeField] List<BuildingData> _humanData = new();
    [SerializeField] List<BuildingData> _elfData = new();
    [SerializeField] List<BuildingData> _newLandData = new();
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
