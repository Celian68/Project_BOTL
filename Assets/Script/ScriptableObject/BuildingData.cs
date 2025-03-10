using UnityEngine;
using BOTL.Data;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BuildingData", menuName = "ScriptableObject/BuildingData")]
public class BuildingData : ScriptableObject
{
    [SerializeField] private string buildId;
    [SerializeField] private string displayName;
    [SerializeField] Faction faction;
    [SerializeField] private GameObject buildPrefab; 
    [SerializeField] List<BuildingStats> buildStats;

    public string BuildId => buildId;
    public string DisplayName => displayName;
    public Faction Faction => faction;
    public GameObject BuildPrefab => buildPrefab;

    public BuildingStats GetBuildStats(Level level)
    {
        return buildStats[(int)level];
    }
    
    public BuildingStats GetSpecificBuildStats(int idx)
    {
        return buildStats[idx];
    }
}
