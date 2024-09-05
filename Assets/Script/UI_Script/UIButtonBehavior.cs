using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Transform trans;

    public int cost;

    public string description;

    public float type;

    void Start()
    {
        trans = transform.Find("ButtonBackgroundIcon");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Réduire la taille du bouton lorsqu'il est survolé
        trans.localScale = new Vector3(trans.localScale.x - 0.1f, trans.localScale.y - 0.1f, 1f);
        popUpActive();
    }

    public void OnClick() {
        InfoPopUpBehavior._instance.Visibility(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Rétablir la taille du bouton lorsque le curseur quitte le bouton
        trans.localScale = new Vector3(trans.localScale.x + 0.1f, trans.localScale.y + 0.1f, 1f);
        InfoPopUpBehavior._instance.Visibility(false);
    }

    private void OnMouseEnter() {
        trans.localScale = new Vector3(trans.localScale.x - 0.2f, trans.localScale.y - 0.2f, 1f);
        popUpActive();
    }

    private void OnMouseDown() {
        OnClick();
    }

    private void OnMouseExit() {
        trans.localScale = new Vector3(trans.localScale.x + 0.2f, trans.localScale.y + 0.2f, 1f);
        InfoPopUpBehavior._instance.Visibility(false);
    }

    private void InfoType()
    {
        // En attendant d'avoir une liste d'unité qui change entre chaque partie pour récupérer la description lié à chaque unité
        switch (type)
        {
            case 0:
                InfoPopUpBehavior._instance.SetDescription(description, cost);
                break;
            case 1:
                GameObject castle = GameObject.FindGameObjectWithTag("Castle1");
                InfoPopUpBehavior._instance.SetDescription("Améliore  le  château  au  niveau  " + castle.GetComponent<Castle>().getLevel(), castle.GetComponent<Castle>().nextLevelUpCost());
                break;
            case 2:
                GameObject castle2 = GameObject.FindGameObjectWithTag("Castle2");
                InfoPopUpBehavior._instance.SetDescription("Améliore  le  château  au  niveau  " + castle2.GetComponent<Castle>().getLevel(), castle2.GetComponent<Castle>().nextLevelUpCost());
                break;
        }
    }

    public void popUpActive() {
        if (type != -1) {
            InfoPopUpBehavior._instance.Visibility(true);
            InfoType();
        }
    }
}