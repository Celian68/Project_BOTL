public class WaitListCancelButton : UIButton
{

    protected override void Start()
    {
        base.Start();
        SetDescription("Annuler");
    }

    public override void OnClick()
    {
        if (!IsActive()) return;
        base.OnClick();
        UnitWaitList._instance.RemoveUnit();
    }
}