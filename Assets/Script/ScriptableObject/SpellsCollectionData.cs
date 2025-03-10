using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpellsCollectionData", menuName = "ScriptableObject/SpellsCollectionData")]
public class SpellsCollectionData : ScriptableObject
{
    [SerializeField] List<SpellData> _humanData = new List<SpellData>();
    [SerializeField] List<SpellData> _elfData = new List<SpellData>();
    [SerializeField] List<SpellData> _newLandData = new List<SpellData>();

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
