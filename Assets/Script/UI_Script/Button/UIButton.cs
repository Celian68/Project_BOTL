using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIButton : AbstractButton, IPointerEnterHandler, IPointerExitHandler {
    
    [SerializeField] protected GameObject cooldownOverlay;

    protected virtual void Start()
    {
        cooldownOverlay.GetComponent<Image>().fillAmount = currentCooldown;
    }

    protected virtual void Update()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown < 0f)
                currentCooldown = 0f;
            cooldownOverlay.GetComponent<Image>().fillAmount = currentCooldown / cooldown;
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        trans.localScale = new Vector3(trans.localScale.x - 0.1f, trans.localScale.y - 0.1f, 1f);
        CustomCursorEnter();
    }

    public virtual void OnClick() {
        if (IsActive()) CustomClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        trans.localScale = new Vector3(trans.localScale.x + 0.1f, trans.localScale.y + 0.1f, 1f);
        CustomCursorExit();
    }

    public void StartCooldown() {
        currentCooldown = cooldown;
        cooldownOverlay.GetComponent<Image>().fillAmount = 1f;
    }
}