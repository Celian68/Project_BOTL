using UnityEngine;

public class Timer_Factory : MonoBehaviour
{
    public static Timer_Factory _instance;

    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    public void StartTimer(float time, System.Action action)
    {
        StartCoroutine(Timer(time, action));
    }

    private System.Collections.IEnumerator Timer(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}