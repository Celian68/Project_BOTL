using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerProgressionData", menuName = "ScriptableObject/PlayerProgressionData")]
public class PlayerProgressionData : ScriptableObject
{
    [SerializeField] Team team;
    [SerializeField] Faction faction;
    [SerializeField] Level castleLevel;
    [SerializeField] Dictionary<UnitName, Level> unitLevels;
    [SerializeField] Level heroLevel;

    public Team Team => team;
    public Faction Faction => faction;
    public Level CastleLevel => castleLevel;
    public Level HeroLevel => heroLevel;

    public void Initialize(Faction faction, List<UnitName> selectedUnits = null)
{
    this.faction = faction;
    castleLevel = Level.Level1;
    heroLevel = Level.Level1;

    unitLevels = new Dictionary<UnitName, Level>();

    List<UnitName> unitsToUse = selectedUnits ?? new List<UnitName> {UnitName.Knight, UnitName.Orc};

    foreach (UnitName unitName in unitsToUse)
    {
        unitLevels[unitName] = Level.Level1;
    }
}

    public Level GetUnitLevel(UnitName unitName)
    {
        if (unitLevels.ContainsKey(unitName))
            return unitLevels[unitName];
        return Level.Level1;
    }

    public void UpgradeUnit(UnitName unitName)
    {
        if (unitLevels.ContainsKey(unitName) && unitLevels[unitName] < Level.Level3)
        {
            unitLevels[unitName]++;
            Debug.Log($"{unitName} amélioré au niveau {unitLevels[unitName]}");
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
}
