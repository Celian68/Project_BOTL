using UnityEngine;

public abstract class AbstractButton : MonoBehaviour
{
    [SerializeField] protected Transform trans;
    protected float cooldown = 0.3f;
    protected float currentCooldown = 0;
    protected int cost = -1;
    protected string description;

    public void CustomCursorEnter()
    {
        PopUpActive();
    }

    public virtual void CustomClick() {
        InfoPopUpBehavior._instance.Visibility(false);
    }

    public void CustomCursorExit()
    {
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

    protected bool IsActive() {
        return currentCooldown == 0;
    }
}