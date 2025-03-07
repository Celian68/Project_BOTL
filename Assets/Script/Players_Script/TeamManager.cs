using UnityEngine;
using BOTL.Data;

public class TeamManager : MonoBehaviour
{

    public static TeamManager _instance;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    public Team getTeamWithTag(string tag) {
        if (tag == "Team1") {
            return Team.Team1;
        }else{
            return Team.Team2;
        }
    }
}
