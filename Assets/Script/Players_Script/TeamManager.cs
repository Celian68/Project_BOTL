using UnityEngine;

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

    public bool getTeamWithTag(string tag) {
        if (tag == "Team1") {
            return false;
        }else if (tag == "Team2") {
            return true;
        }
        return false;
    }
}
