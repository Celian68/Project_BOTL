using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "PlayerProgressionData", menuName = "ScriptableObject/PlayerProgressionData")]
public class PlayerProgressionData : ScriptableObject
{
    Faction faction;
    [SerializeField] CastleData castleData;
    Level castleLevel;
    Dictionary<UnitData, Level> unitsData;
    Dictionary<SpellData, Level> spellsData;
    UnitData heroData;
    Level heroLevel;

    public Faction Faction => faction;
    public Level CastleLevel => castleLevel;
    public Level HeroLevel => heroLevel;
    public CastleData CastleData => castleData;
    public UnitData HeroData => heroData;

    public void Initialize(Faction faction, List<UnitData> selectedUnits, List<SpellData> selectedSpells, UnitData selectedHero)
{
    this.faction = faction;
    castleLevel = Level.Level1;
    heroLevel = Level.Level1;

    unitsData = new Dictionary<UnitData, Level>();
    spellsData = new Dictionary<SpellData, Level>();
    heroData = selectedHero;


    foreach (UnitData unitData in selectedUnits)
    {
        unitsData[unitData] = Level.Level1;
    }

    foreach (SpellData spellData in selectedSpells)
    {
        spellsData[spellData] = Level.Level1;
    }
}

    public Level GetUnitLevel(UnitData unitData)
    {
        if (unitsData.ContainsKey(unitData))
            return unitsData[unitData];
        return Level.Level1;
    }

    public Level GetSpellLevel(SpellData spellData)
    {
        if (spellsData.ContainsKey(spellData))
            return spellsData[spellData];
        return Level.Level1;
    }

    public void UpgradeUnit(UnitData unitData)
    {
        if (unitsData.ContainsKey(unitData) && unitsData[unitData] < Level.Level3)
        {
            unitsData[unitData]++;
            Debug.Log($"{unitData} amélioré au niveau {unitsData[unitData]}");
        }
    }

    public void UpgradeSpell(SpellData spellData)
    {
        if (spellsData.ContainsKey(spellData) && spellsData[spellData] < Level.Level3)
        {
            spellsData[spellData]++;
            Debug.Log($"{spellData} amélioré au niveau {spellsData[spellData]}");
        }
    }

    public void UpgradeCastle()
    {
        if (castleLevel < Level.Level3)
        {
            castleLevel++;
            Debug.Log($"Château amélioré au niveau {castleLevel}");
        }
    }

    public void UpgradeHero()
    {
        if (heroLevel < Level.Level3)
        {
            heroLevel++;
            Debug.Log($"Héros amélioré au niveau {heroLevel}");
        }
    }

    public UnitData GetUnitData(int index) {
        return unitsData.Keys.ToList()[index];
    }

    public List<UnitData> GetUnitsData() {
        return unitsData.Keys.ToList();
    }

    public SpellData GetSpellData(int index) {
        return spellsData.Keys.ToList()[index];
    }

    public List<SpellData> GetSpellsData() {
        return spellsData.Keys.ToList();
    }
}
