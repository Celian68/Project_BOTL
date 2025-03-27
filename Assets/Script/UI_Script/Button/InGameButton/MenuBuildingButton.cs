using UnityEngine;

public class MenuBuildingButton : InGameButton
{

    [SerializeField] float batimentType;
    [SerializeField] GameObject building;
    [SerializeField] GameObject buildButton;

    void Start()
    {
        gameObject.SetActive(true);
        SetCost(-1);
        SetCooldown(0.1f);
        switch (batimentType)
        {
            case 0:
                SetDescription("Annuler  la  construction");
                break;
            case 1:
                SetDescription("Une  Ferme  qui  produit  des  ressources");
                SetCost(75);
                break;
            default:
                SetDescription("Rien  à  construire  pour  l'instant");
                break;
        }
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        switch (batimentType)
        {
            case 0:
                buildButton.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                break;
            case 1:
                if (RessourceManager._instance.ConsumResources(gameObject.GetComponent<AbstractButton>().GetUpgradeCost(), TeamManager._instance.GetTeamWithTag(building.tag)))
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