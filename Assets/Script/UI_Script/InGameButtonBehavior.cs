using UnityEngine;

public class InGameButtonBehavior : MonoBehaviour
{

    public string description;

    public float cost;

    private Transform trans;

    void Start() {
        trans = transform.Find("ButtonBackgroundIcon");
    }

    private void OnMouseEnter() {
        trans.localScale = new Vector3(trans.localScale.x - 0.2f, trans.localScale.y - 0.2f, 1f);
    }

    private void OnMouseExit() {
        trans.localScale = new Vector3(trans.localScale.x + 0.2f, trans.localScale.y + 0.2f, 1f);
    }
}
