using UnityEngine;
using UnityEngine.UI;
using BOTL.Enum;

public class RessourceManager : MonoBehaviour
{

    public static RessourceManager _instance;

    // Gestion des ressources et autres variables globales pour le joueur 1
    float maxRessourcesJ1; // Float that represent the maximum number of ressources that the player can have
    float currentRessourcesJ1; // Float that represent the current number of ressources that the player have
    float ressourcesPerSecJ1; // Float that represent the current number of ressources that the player gain every second

    public Text ressourcesCountJ1;

    // Gestion des ressources et autres variables globales pour le joueur 2
    float maxRessourcesJ2; // Float that represent the maximum number of ressources that the player can have
    float currentRessourcesJ2; // Float that represent the current number of ressources that the player have
    float ressourcesPerSecJ2; // Float that represent the current number of ressources that the player gain every second

    public Text ressourcesCountJ2;

    void Awake() { 
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null && _instance != this) { 
            Destroy(this); 
        }else{ 
            _instance = this; 
        } 
    }

    void Start() {
        currentRessourcesJ1 = 100;
        currentRessourcesJ2 = 100;
        maxRessourcesJ1 = 100;
        maxRessourcesJ2 = 100;
        ressourcesPerSecJ1 = 1;
        ressourcesPerSecJ2 = 1;
        InvokeRepeating("GenerateRessources", 0f, 0.5f);  
    }

    void Update() {
        ressourcesCountJ1.text = currentRessourcesJ1.ToString();
        ressourcesCountJ2.text = currentRessourcesJ2.ToString();
    }


    void GenerateRessources() { 
        if (currentRessourcesJ1 < maxRessourcesJ1) {
            currentRessourcesJ1 += ressourcesPerSecJ1;
        }else{
            currentRessourcesJ1 = maxRessourcesJ1;
        }

        if (currentRessourcesJ2 < maxRessourcesJ2) {
            currentRessourcesJ2 += ressourcesPerSecJ2;
        }else{
            currentRessourcesJ2 = maxRessourcesJ2;
        }
    }

    // Méthodes pour gérer les ressources
    public void AddResources(float montant, Team player)
    {
        if (player == Team.Team2) {
            currentRessourcesJ2 += montant;
            if (currentRessourcesJ2 > maxRessourcesJ2)
            {
                currentRessourcesJ2 = maxRessourcesJ2;
            }
        }else{
            currentRessourcesJ1 += montant;
            if (currentRessourcesJ1 > maxRessourcesJ1)
            {
                currentRessourcesJ1 = maxRessourcesJ1;
            }
        }
    }

    public bool ConsumResources(float montant, Team player)
    {
        if (player == Team.Team2) {
            if (currentRessourcesJ2 >= montant)
            {
                currentRessourcesJ2 -= montant;
                return true;
            }
        }else{
            if (currentRessourcesJ1 >= montant)
            {
                currentRessourcesJ1 -= montant;
                return true;
            }
        }
        return false;
    }

    public bool CheckResources(float montant, Team player)
    {
        if (player == Team.Team2) {
            return currentRessourcesJ2 >= montant;
        }else{
            return currentRessourcesJ1 >= montant;
        }
    }

    public void setMaxResources(float ressources, Team player)
    {
        if (player == Team.Team2) {
            maxRessourcesJ2 = ressources;
        }else{
            maxRessourcesJ1 = ressources;
        }
    }

    public void setResourcePerSec(float ressource, Team player)
    {
        if (player == Team.Team2) {
            ressourcesPerSecJ2 = ressource;
        }else{
            ressourcesPerSecJ1 = ressource;
        }
    }
}
