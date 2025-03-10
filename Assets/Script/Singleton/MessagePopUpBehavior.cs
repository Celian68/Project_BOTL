using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopUpBehavior : MonoBehaviour
{
    public static MessagePopUpBehavior _instance;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        setTransparency(0);
    }

    private float getTransparency()
    {
        return gameObject.GetComponent<Image>().color.a;
    }

    public void setTransparency(float alpha)
    {
        alpha = alpha/10;

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

    public void setMessage(string message)
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = message;
    }

    public void showPopUp(string message)
    {
        setMessage(message);
        setTransparency(100);

        StopAllCoroutines();
        CancelInvoke("StartHidePopUpCoroutine");

        Invoke("StartHidePopUpCoroutine", 2);
    }

    private void StartHidePopUpCoroutine()
    {
        StartCoroutine(FadeOutPopUp());
    }

    private IEnumerator FadeOutPopUp()
    {
        float duration = 2f; // Durée de la transition en secondes
        float startAlpha = getTransparency();
        float endAlpha = 0;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            setTransparency(alpha);
            yield return null;
        }

        setTransparency(endAlpha); // S'assurer que la transparence est entièrement à zéro
    }
}
