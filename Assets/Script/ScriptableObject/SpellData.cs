using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpellData", menuName = "ScriptableObject/SpellData")]
public class SpellData : ScriptableObject
{
    [SerializeField] string spellId;
    [SerializeField] string displayName;
    [SerializeField] Faction faction;
    [SerializeField] GameObject spellPrefab;
    [SerializeField] List<SpellStats> spellStats;
    [SerializeField] List<SpellTriggerData> spellTriggers;

    public string SpellId => spellId;
    public string DisplayName => displayName;
    public Faction Faction => faction;
    public GameObject SpellPrefab => spellPrefab;

    public SpellStats GetSpellStats(Level level)
    {
        return spellStats[(int)level];
    }
    
    public SpellStats GetSpecificSpellStats(int idx)
    {
        return spellStats[idx];
    }
}
