using UnityEngine;
using BOTL.Data;

public class HeroOrderButton : AbstractButton {
    [SerializeField] UnitState order;
    [SerializeField] string descriptionState;

    void Start()
    {
        gameObject.SetActive(true);
        SetDescription(descriptionState);
        SetCost(-1);
        SetCooldown(0.1f);
    }

    public override void OnClick() {
        base.OnClick();
        HeroController._instance.SetHeroOrder(order);
    }
}