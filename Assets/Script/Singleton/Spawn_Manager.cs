using UnityEngine;
using BOTL.Data;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField] Transform spawn1;
    [SerializeField] Transform spawn2;

    public static Spawn_Manager _instance;

    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
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
            Instantiate(data.TargetPrefab, spawn.position, Quaternion.identity);
        }
    }
}
