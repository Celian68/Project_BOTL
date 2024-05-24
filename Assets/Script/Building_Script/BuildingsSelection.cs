using UnityEngine;

public class BuildingsSelection : MonoBehaviour
{
    public float batimentType;
    public GameObject building; 
    public GameObject buildButton;

    private void OnMouseDown() {
        switch (batimentType)
        {
            case 0:
                buildButton.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                break;
            case 1:
                if (RessourceManager._instance.ConsumResources(gameObject.GetComponent<UIButtonBehavior>().cost, TeamManager._instance.getTeamWithTag(building.tag)))
                {
                    building.GetComponent<Building>().SetBuildingType(batimentType);
                    transform.parent.gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}
