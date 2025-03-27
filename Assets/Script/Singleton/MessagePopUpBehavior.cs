using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopUpBehavior : MonoBehaviour
{
    public static MessagePopUpBehavior _instance;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        SetTransparency(0);
    }

    private float GetTransparency()
    {
        return gameObject.GetComponent<Image>().color.a;
    }

    public void SetTransparency(float alpha)
    {
        alpha /= 10;

        Color color = gameObject.GetComponent<Image>().color;
        color.a = alpha;
        gameObject.GetComponent<Image>().color = color;

        Color colorBackground = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color;
        colorBackground.a = alpha;
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = colorBackground;

        Color colorText = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().color;
        colorText.a = alpha;
        gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().color = colorText;
    }

    public void SetMessage(string message)
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = message;
    }

    public void ShowPopUp(string message)
    {
        SetMessage(message);
        SetTransparency(100);

        StopAllCoroutines();
        CancelInvoke(nameof(StartHidePopUpCoroutine));

        Invoke(nameof(StartHidePopUpCoroutine), 2);
    }

    private void StartHidePopUpCoroutine()
    {
        StartCoroutine(FadeOutPopUp());
    }

    private IEnumerator FadeOutPopUp()
    {
        float duration = 2f; // Durée de la transition en secondes
        float startAlpha = GetTransparency();
        float endAlpha = 0;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            SetTransparency(alpha);
            yield return null;
        }

        SetTransparency(endAlpha); // S'assurer que la transparence est entièrement à zéro
    }
}
