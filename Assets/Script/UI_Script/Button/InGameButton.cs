using UnityEngine;

public abstract class InGameButton : AbstractButton
{
    private void OnMouseEnter()
    {
        trans.localScale = new Vector3(trans.localScale.x - 0.2f, trans.localScale.y - 0.2f, 1f);
        CustomCursorEnter();
    }

    public virtual void OnMouseDown()
    {
        CustomClick();
    }

    private void OnMouseExit()
    {
        trans.localScale = new Vector3(trans.localScale.x + 0.2f, trans.localScale.y + 0.2f, 1f);
        CustomCursorExit();
    }
}