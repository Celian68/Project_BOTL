using UnityEngine;
using UnityEngine.UI;

public class InfoPopUpBehavior : MonoBehaviour
{

    private Vector2 size;

    public Transform cout;
    public Transform description;
    public Transform icon;

    public bool activ;

    public static InfoPopUpBehavior _instance;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    void Start()
    {
        size = GetComponent<RectTransform>().sizeDelta;
        size = new Vector2(size.x * 1000 - 100, size.y * 1000 - 100);
        Visibility(false);
        activ = true;
    }

    void Update()
    {
        // Suivre la position de la souris en permanence
        UpdatePopupPosition();

        // Vérifie les valeurs du cout
        CheckCost();
    }

    void UpdatePopupPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 popupPosition;

        // Obtenir les dimensions de l'écran
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Déterminer le quadrant de l'écran où se trouve la souris
        if (mousePosition.x < screenWidth / 2f)
        {
            // La souris est dans la moitié gauche de l'écran
            if (mousePosition.y < screenHeight / 2f)
            {
                // La souris est dans le quadrant inférieur gauche de l'écran
                popupPosition = mousePosition + new Vector3(size.x, size.y/2, 0f); // ajustez la position du pop-up selon vos besoins
            }
            else
            {
                // La souris est dans le quadrant supérieur gauche de l'écran
                popupPosition = mousePosition + new Vector3(size.x, -size.y/2, 0f); // ajustez la position du pop-up selon vos besoins
            }
        }
        else
        {
            // La souris est dans la moitié droite de l'écran
            if (mousePosition.y < screenHeight / 2f)
            {
                // La souris est dans le quadrant inférieur droit de l'écran
                popupPosition = mousePosition + new Vector3(-size.x, size.y/2, 0f); // ajustez la position du pop-up selon vos besoins
            }
            else
            {
                // La souris est dans le quadrant supérieur droit de l'écran
                popupPosition = mousePosition + new Vector3(-size.x, -size.y/2, 0f); // ajustez la position du pop-up selon vos besoins
            }
        }

        // Convertir la position du pop-up de coordonnées de l'écran à des coordonnées du monde
        transform.position = popupPosition;
    }

    public bool setActiv() {
        return activ = !activ;
    }

    public void SetDescription(string newDescription, float newCost)
    {
        // Mettre à jour le cout du pop-up
        cout.GetComponent<UnityEngine.UI.Text>().text = newCost.ToString();
        
        // Mettre à jour la description du pop-up
        description.GetComponent<UnityEngine.UI.Text>().text = newDescription;
    }

    private void CheckCost()
    {
        // Vérifier si le coût est négatif
        if (float.Parse(cout.GetComponent<UnityEngine.UI.Text>().text) < 0)
        {
            // Cacher le coût
            cout.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
        }
        else
        {
            // Afficher le coût
            cout.gameObject.SetActive(true);
            icon.gameObject.SetActive(true);
        }
    }

    public void Visibility(bool state)
    {
        if (!state || (state && activ)) {
            // Activer ou désactiver le pop-up
            gameObject.GetComponent<Image>().enabled = state;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = state;
            gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = state;
            gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().enabled = state;
            gameObject.transform.GetChild(3).gameObject.GetComponent<Image>().enabled = state;
        }
    }
}
