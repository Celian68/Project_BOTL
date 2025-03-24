using UnityEngine;

public class BuildButton : InGameButton {

    [SerializeField] GameObject menu;

    void Start()
    {
        gameObject.SetActive(true);
        SetDescription("Construit  quelque  chose  ici");
        SetCost(-1);
        SetCooldown(0.1f);
    }

    public override void OnMouseDown() {
        base.OnMouseDown();
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}