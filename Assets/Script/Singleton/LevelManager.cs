using System;
using System.Collections.Generic;
using BOTL.Data;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager _instance;
    [SerializeField] PlayerProgressionData player1;
    [SerializeField] PlayerProgressionData player2;
    [SerializeField] UnitsCollectionData unitsDataCollection;
    [SerializeField] SpellsCollectionData spellsDataCollection;
    [SerializeField] UnitsCollectionData herosDataCollection;
    [SerializeField] BuildingsCollectionData buildingsDataCollection;

    public event Action<Team, Level> onCastleLevelUp;
    public event Action<Team, Level> onHeroLevelUp;
    public event Action<Team, UnitData, Level> onUnitLevelUp;
    public event Action<Team, SpellData, Level> onSpellLevelUp;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        var defaultUnits = new List<UnitData>
        {
            unitsDataCollection.GetData(Faction.Human, "HU01"),
            unitsDataCollection.GetData(Faction.NewLand, "NU01")
        };
        var defaultSpell = new List<SpellData>
        {
            spellsDataCollection.GetData(Faction.NewLand, "NS01")
        };
        var defaultHero = unitsDataCollection.GetData(Faction.Human, "HH01");
        player1.Initialize(Faction.Human, defaultUnits, defaultSpell, defaultHero);
        player2.Initialize(Faction.NewLand, defaultUnits, defaultSpell, defaultHero);
    }

    void Start()
    {
        Army_Button._instance.SetSpells(player1.GetSpellsData());
        Army_Button._instance.SetUnits(player1.GetUnitsData(), Team.Team1);
        Army_Button._instance.SetUnits(player2.GetUnitsData(), Team.Team2);
    }

    public Level GetLevelCastle(Team team)
    {
        return GetPlayerProgressionData(team).CastleLevel;
    }

    public Level getLevelHero(Team team)
    {
        return GetPlayerProgressionData(team).HeroLevel;
    }

    public Level GetLevelUnit(Team team, UnitData unitData)
    {
        return GetPlayerProgressionData(team).GetUnitLevel(unitData);
    }

    public Level GetLevelSpell(Team team, SpellData spellData)
    {
        return GetPlayerProgressionData(team).GetSpellLevel(spellData);
    }

    public void LevelUpCastle(Team team)
    {
        if (RessourceManager._instance.ConsumResources(GetPlayerProgressionData(team).CastleData.GetUpgradeCost(GetLevelCastle(team)), team))
        {
            GetPlayerProgressionData(team).UpgradeCastle();
            onCastleLevelUp?.Invoke(team, GetLevelCastle(team));
        }
    }

    public void LevelUpHero(Team team)
    {
        if (RessourceManager._instance.ConsumResources(GetPlayerProgressionData(team).HeroData.GetUpgradeCost(GetLevelCastle(team)), team))
        {
            GetPlayerProgressionData(team).UpgradeHero();
            onHeroLevelUp?.Invoke(team, getLevelHero(team));
        }
    }

    public void LevelUpUnit(Team team, UnitData unitData)
    {
        if (RessourceManager._instance.ConsumResources(unitData.GetUpgradeCost(GetLevelCastle(team)), team))
        {
            GetPlayerProgressionData(team).UpgradeUnit(unitData);
            onUnitLevelUp?.Invoke(team, unitData, GetLevelUnit(team, unitData));
        }
    }

    public void LevelUpSpell(Team team, SpellData spellData)
    {
        if (RessourceManager._instance.ConsumResources(spellData.GetUpgradeCost(GetLevelCastle(team)), team))
        {
            GetPlayerProgressionData(team).UpgradeSpell(spellData);
            onSpellLevelUp?.Invoke(team, spellData, GetLevelSpell(team, spellData));
        }
    }


    public PlayerProgressionData GetPlayerProgressionData(Team team)
    {
        if (team == Team.Team1)
        {
            return player1;
        }
        else
        {
            return player2;
        }
    }
}
