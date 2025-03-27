using UnityEngine;
using Assets.Script.AssetsScripts.Enum;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpellsCollectionData", menuName = "ScriptableObject/SpellsCollectionData")]
public class SpellsCollectionData : ScriptableObject
{
    [SerializeField] List<SpellData> _humanData = new();
    [SerializeField] List<SpellData> _elfData = new();
    [SerializeField] List<SpellData> _newLandData = new();

    public SpellData GetData(Faction faction, string spellID)
    {
        return faction switch
        {
            Faction.Human => _humanData.Find(x => x.SpellId == spellID),
            Faction.Elven => _elfData.Find(x => x.SpellId == spellID),
            Faction.NewLand => _newLandData.Find(x => x.SpellId == spellID),
            _ => null,
        };
    }

    public List<SpellData> GetDataList(Faction faction)
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
