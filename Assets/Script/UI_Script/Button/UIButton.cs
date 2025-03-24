using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UIButton : AbstractButton, IPointerEnterHandler, IPointerExitHandler {
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsActive()) trans.localScale = new Vector3(trans.localScale.x - 0.1f, trans.localScale.y - 0.1f, 1f);
        CustomCursorEnter();
    }

    public virtual void OnClick() {
        CustomClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CustomCursorExit();
    }
}