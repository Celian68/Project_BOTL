using UnityEngine;
using Assets.Script.AssetsScripts.Enum;

public class HeroOrderButton : UIButton
{
    [SerializeField] UnitState order;
    [SerializeField] string descriptionState;

    protected override void Start()
    {
        base.Start();
        gameObject.SetActive(true);
        SetDescription(descriptionState);
    }

    public override void OnClick()
    {
        if (!IsActive()) return;
        base.OnClick();
        HeroController._instance.SetHeroOrder(order);
        StartCooldown();
    }
}