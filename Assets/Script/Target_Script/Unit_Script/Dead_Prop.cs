using UnityEngine;

public class DeadProp : MonoBehaviour
{
    readonly float delayBeforeShrink = 10f;
    readonly float shrinkDuration = 5f;

    private bool isShrinking = false;
    private float shrinkTimer = 0f;
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
        Invoke(nameof(StartShrinking), delayBeforeShrink);
    }

    void StartShrinking()
    {
        isShrinking = true;
    }

    void Update()
    {
        if (isShrinking)
        {
            shrinkTimer += Time.deltaTime;
            float progress = shrinkTimer / shrinkDuration;

            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, progress);

            if (progress >= 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
