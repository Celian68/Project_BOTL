using System;
using BOTL.Data;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager _instance;
    [SerializeField] GameObject LevelUpButtonCastle1;
    [SerializeField] GameObject LevelUpButtonCastle2;
    [SerializeField] PlayerProgressionData Player1;
    [SerializeField] PlayerProgressionData Player2;
    [SerializeField] UnitsCollectionData UnitDataCollection;

    public event Action<Team, Level> OnCastleLevelUp;
    public event Action<Team, Level> OnHeroLevelUp;
    public event Action<Team, UnitData, Level> OnUnitLevelUp;

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
    }

    void Start()
    {
        Player1.Initialize(Faction.Human);
        Player2.Initialize(Faction.NewLand);
        LevelUpButtonCastle1.SetActive(true);
        LevelUpButtonCastle2.SetActive(true);
    }

    public Level getLevelCastle(Team team)
    {
        return GetPlayerProgressionData(team).CastleLevel;
    }

    public Level getLevelHero(Team team)
    {
        return GetPlayerProgressionData(team).HeroLevel;
    }

    public Level getLevelUnit(Team team, UnitData unitData)
    {
        return GetPlayerProgressionData(team).GetUnitLevel(unitData);
    }

    public void LevelUpCastle(Team team)
    {
        if (RessourceManager._instance.ConsumResources(GetPlayerProgressionData(team).CastleData.GetUpgradeCost(getLevelCastle(team)), team))
        {
            GetPlayerProgressionData(team).UpgradeCastle();
            if (GetPlayerProgressionData(team).CastleLevel == Level.Level3)
            {
                GetPlayerButton(team).SetActive(false);
            }
            OnCastleLevelUp?.Invoke(team, getLevelCastle(team));
        }
    }

    public void LevelUpHero(Team team)
    {
        if (RessourceManager._instance.ConsumResources(GetPlayerProgressionData(team).HeroData.GetUpgradeCost(getLevelCastle(team)), team))
        {
            GetPlayerProgressionData(team).UpgradeHero();
            OnHeroLevelUp?.Invoke(team, getLevelHero(team));
        }
    }

    public void LevelUpUnit(Team team, UnitData unitData)
    {
        if (RessourceManager._instance.ConsumResources(unitData.GetUpgradeCost(getLevelCastle(team)), team))
        {
            GetPlayerProgressionData(team).UpgradeUnit(unitData);
            OnUnitLevelUp?.Invoke(team, unitData, getLevelUnit(team, unitData));
        }
    }

    public void LevelUpCastleInt(int team)
    {
        LevelUpCastle((Team)team);
    }

    public void LevelUpHeroInt(int team)
    {
        LevelUpHero((Team)team);
    }

    public void LevelUpUnitInt(int team, int unitIndex)
    {
        LevelUpUnit((Team)team, GetPlayerProgressionData((Team)team).getUnitData(unitIndex));
    }

    public PlayerProgressionData GetPlayerProgressionData(Team team)
    {
        if (team == Team.Team1)
        {
            return Player1;
        }
        else
        {
            return Player2;
        }
    }

    public GameObject GetPlayerButton(Team team)
    {
        if (team == Team.Team1)
        {
            return LevelUpButtonCastle1;
        }
        else
        {
            return LevelUpButtonCastle2;
        }
    }

    public UnitsCollectionData getUnitDataCollection()
    {
        return UnitDataCollection;
    }
}
