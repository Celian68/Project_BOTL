using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AbstractButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Transform trans;
    protected float cooldown = 0;
    protected int currentCooldown = 0;
    protected int cost;
    protected string description;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsActive()) trans.localScale = new Vector3(trans.localScale.x - 0.1f, trans.localScale.y - 0.1f, 1f);
        PopUpActive();
    }

    public virtual void OnClick() {
        InfoPopUpBehavior._instance.Visibility(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        trans.localScale = new Vector3(trans.localScale.x + 0.1f, trans.localScale.y + 0.1f, 1f);
        InfoPopUpBehavior._instance.Visibility(false);
    }


    // For button in the scene
    private void OnMouseEnter() {
        trans.localScale = new Vector3(trans.localScale.x - 0.2f, trans.localScale.y - 0.2f, 1f);
        PopUpActive();
    }

    private void OnMouseDown() {
        OnClick();
    }

    private void OnMouseExit() {
        trans.localScale = new Vector3(trans.localScale.x + 0.2f, trans.localScale.y + 0.2f, 1f);
        InfoPopUpBehavior._instance.Visibility(false);
    }

    public void PopUpActive() {
        InfoPopUpBehavior._instance.Visibility(true);
        InfoPopUpBehavior._instance.SetDescription(description, cost);
    }

    public float GetUpgradeCost() {
        return cost;
    }

    protected void SetCost(int cost) {
        this.cost = cost;
    }

    protected void SetDescription(string description) {
        this.description = description;
    }

    protected void SetCooldown(float cooldown) {
        this.cooldown = cooldown;
    }

    bool IsActive() {
        return currentCooldown == 0;
    }
}