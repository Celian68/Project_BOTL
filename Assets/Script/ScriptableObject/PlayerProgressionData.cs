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
    UnitData heroData;
    Level heroLevel;

    public Faction Faction => faction;
    public Level CastleLevel => castleLevel;
    public Level HeroLevel => heroLevel;
    public CastleData CastleData => castleData;
    public UnitData HeroData => heroData;

    public void Initialize(Faction faction, List<UnitData> selectedUnits, UnitData selectedHero)
{
    this.faction = faction;
    castleLevel = Level.Level1;
    heroLevel = Level.Level1;

    unitsData = new Dictionary<UnitData, Level>();
    heroData = selectedHero;


    foreach (UnitData unitData in selectedUnits)
    {
        unitsData[unitData] = Level.Level1;
    }
}

    public Level GetUnitLevel(UnitData unitData)
    {
        if (unitsData.ContainsKey(unitData))
            return unitsData[unitData];
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

    public UnitData getUnitData(int index) {
        return unitsData.Keys.ToList()[index];
    }
}
