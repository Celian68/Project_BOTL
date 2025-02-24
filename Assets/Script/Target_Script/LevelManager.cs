using System;
using BOTL.Enum;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager _instance;

    void Awake() { 
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    void Start()
    {
        Player1.Initialize(Faction.Human);
        Player2.Initialize(Faction.NewLand);
    }

    [SerializeField] PlayerProgressionData Player1;
    [SerializeField] PlayerProgressionData Player2;

    public event Action<Team, Level> OnCastleLevelUp;
    public event Action<Team, Level> OnHeroLevelUp;
    public event Action<Team, UnitName, Level> OnUnitLevelUp;

    public Level getLevelCastle(Team team)
    {
        if (team == Team.Team1)
        {
            return Player1.CastleLevel;
        }
        else
        {
            return Player2.CastleLevel;
        }
    }

    public Level getLevelHero(Team team)
    {
        if (team == Team.Team1)
        {
            return Player1.HeroLevel;
        }
        else
        {
            return Player2.HeroLevel;
        }
    }

    public Level getLevelUnit(Team team, UnitName unitName)
    {
        if (team == Team.Team1)
        {
            return Player1.GetUnitLevel(unitName);
        }
        else
        {
            return Player2.GetUnitLevel(unitName);
        }
    }

    public void LevelUpCastle(Team team)
    {
        if (team == Team.Team1)
        {
            Player1.UpgradeCastle();
        }
        else
        {
            Player2.UpgradeCastle();
        }
        OnCastleLevelUp?.Invoke(team, getLevelCastle(team));
    }

    public void LevelUpHero(Team team)
    {
        if (team == Team.Team1)
        {
            Player1.UpgradeHero();
        }
        else
        {
            Player2.UpgradeHero();
        }
        OnHeroLevelUp?.Invoke(team, getLevelHero(team));
    }

    public void LevelUpUnit(Team team, UnitName unitName)
    {
        if (team == Team.Team1)
        {
            Player1.UpgradeUnit(unitName);
        }
        else
        {
            Player2.UpgradeUnit(unitName);
        }
        OnUnitLevelUp?.Invoke(team, unitName, getLevelUnit(team, unitName));
    }

    public void LevelUpCastleInt(int team)
    {
        LevelUpCastle((Team)team);
    }

    public void LevelUpHeroInt(int team)
    {
        LevelUpHero((Team)team);
    }

    public void LevelUpUnitInt(int team, int unitName)
    {
        LevelUpUnit((Team)team, (UnitName)unitName);
    }
}