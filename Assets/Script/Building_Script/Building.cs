using UnityEngine;

public class Building : MonoBehaviour
{

    public float batimentType = 0;

    public Animator animBuild; // Animator of the Arch

    public void SetBuildingType(float type)
    {
        batimentType = type;
        animBuild.SetInteger("Type", (int)batimentType);
        InitBuildingBehavior();
    }

    private void InitBuildingBehavior()
    {
        switch (batimentType)
        {
            case 1:
                InvokeRepeating(nameof(GenerateRessourcesFarm), 5f, 5f);
                break;
        }
    }

    private void GenerateRessourcesFarm()
    {
        int ressource = 3;
        RessourceManager._instance.AddResources(ressource, TeamManager._instance.GetTeamWithTag(gameObject.tag));
        UI_Manager._instance.ShowNumberText(ressource, transform.position, 0, "+");
    }
}
