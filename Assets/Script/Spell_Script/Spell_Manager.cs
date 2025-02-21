using UnityEngine;

public class Spell_Manager : MonoBehaviour
{


    public GameObject zoneIndicator; // Référence au GameObject qui montre la zone d'impact
    public GameObject meteorPrefab; // Référence au prefab de la météorite
    public Camera mainCamera; // La caméra principale pour suivre la souris
    private bool isSelecting = false; // Indique si le joueur est en mode sélection du sort

    void Update()
    {
        if (isSelecting && zoneIndicator.activeSelf)
        {
            // Faire suivre la zone d'impact à la souris
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            zoneIndicator.transform.position = new Vector3(worldPosition.x, 0, 0);
            if (worldPosition.x < -5.5f)
            {
                zoneIndicator.transform.position = new Vector3(-5.5f, 0, 0);
            }else if (worldPosition.x > 35.5f)
            {
                zoneIndicator.transform.position = new Vector3(35.5f, 0, 0);
            }

            // Vérifie si le joueur clique pour déclencher la météorite
            if (Input.GetMouseButtonDown(0)) // Clic gauche
            {
                CastMeteor();
            }
            if (Input.GetMouseButtonDown(1)) // Clic droit
            {
                isSelecting = false;
                zoneIndicator.SetActive(false);
            }
        }
    }

    public void ActivateSpell()
    {
        // Active la sélection et la zone d'impact
        isSelecting = true;
        zoneIndicator.SetActive(true);
    }

    private void CastMeteor()
    {
        // Déclencher la chute de la météorite
        Vector3 targetPosition = zoneIndicator.transform.position;
        Instantiate(meteorPrefab, new Vector3(targetPosition.x, targetPosition.y + 10f, targetPosition.z), Quaternion.identity);

        // Désactiver la zone d'impact
        isSelecting = false;
        zoneIndicator.SetActive(false);
    }
}
