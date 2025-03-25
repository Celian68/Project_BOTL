using UnityEngine;
using BOTL.Data;

public class HeroOrderButton : UIButton {
    [SerializeField] UnitState order;
    [SerializeField] string descriptionState;

    protected override void Start()
    {
        base.Start();
        gameObject.SetActive(true);
        SetDescription(descriptionState);
        SetCost(-1);
        SetCooldown(0.3f);
    }

    public override void OnClick() {
        if (!IsActive()) return;
        base.OnClick();
        HeroController._instance.SetHeroOrder(order);
        StartCooldown();
    }
}