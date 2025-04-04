using UnityEngine;
using Assets.Script.AssetsScripts.Enum;
using Assets.Script.AssetsScripts.Struct;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SpellData", menuName = "ScriptableObject/SpellData")]
public class SpellData : ScriptableObject
{
    [SerializeField] string spellId;
    [SerializeField] string displayName;
    [SerializeField] string description;
    [SerializeField] Faction faction;
    [SerializeField] GameObject spellPrefab;
    [SerializeField] List<SpellStats> spellStats;

    public string SpellId => spellId;
    public string DisplayName => displayName;
    public string Description => description;
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

    public int GetUpgradeCost(Level currentLevel)
    {
        int idx = (int)currentLevel;
        if (idx < 0 || idx >= spellStats.Count - 1) return -1;
        return spellStats[idx].nextUpgradeCost;
    }

    public void StartTrigger(TriggerType trigger, EffectContext context, Level level)
    {
        List<TriggerData> triggers = GetSpellStats(level).spellTriggers;
        foreach (TriggerData t in triggers)
        {
            t.ApplyEffects(context, trigger);
        }
    }
}
