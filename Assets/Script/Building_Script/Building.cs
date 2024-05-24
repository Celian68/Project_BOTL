using UnityEngine;

public class Building : MonoBehaviour
{

    public float batimentType = 0;

    public Animator animBuild; // Animator of the Arch

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBuildingType(float type) {
        batimentType = type;
        animBuild.SetInteger("Type", (int)batimentType);
        InitBuildingBehavior();
    }

    private void InitBuildingBehavior() {
        switch (batimentType)
        {
            case 1:
                InvokeRepeating("GenerateRessourcesFarm", 5f, 5f); 
                break;
        }
    }

    private void GenerateRessourcesFarm() {
        RessourceManager._instance.AddResources(3, TeamManager._instance.getTeamWithTag(gameObject.tag));
    }
}
