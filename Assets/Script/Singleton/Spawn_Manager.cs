using UnityEngine;
using BOTL.Data;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField] Transform spawn1;
    [SerializeField] Transform spawn2;

    public static Spawn_Manager _instance;

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

    public void Spawn_Unit(int unitIndex, Team team)
    {
        UnitData data = LevelManager._instance.GetPlayerProgressionData(team).GetUnitData(unitIndex);
        if (RessourceManager._instance.ConsumResources(data.GetUnitStats(LevelManager._instance.GetLevelUnit(team, data)).baseCost, team))
        {
            Spawn_Unit(LevelManager._instance.GetPlayerProgressionData(team).GetUnitData(unitIndex), team);
        }
    }

    public GameObject Spawn_Unit(UnitData unit, Team team)
    {
        Transform spawn;
        if (team == Team.Team1)
        {
            spawn = spawn1;
        }
        else
        {
            spawn = spawn2;
        }
        float randomNumber = Random.Range(23, 65) / 100f;
        spawn.position = new Vector3(spawn.position.x, randomNumber, 0);
        return Instantiate(unit.TargetPrefab, spawn.position, Quaternion.identity);
    }

    public Transform getSpawn(Team team)
    {
        if (team == Team.Team1)
        {
            return spawn1;
        }
        else
        {
            return spawn2;
        }
    }
}
