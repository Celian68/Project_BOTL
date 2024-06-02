using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public Text gameOverText;

    public bool gameOver;

    public static GameOverManager _instance;

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
        gameOverMenu.SetActive(false);
        gameOver = false;
    }

    public void setGameOver(bool state, bool player) {
        gameOver = state;

        int intPlayer = player ? 1 : 0;
        intPlayer++;

        if (gameOver) {
            gameOverText.text = "Player " + intPlayer.ToString() + " Win !";
            gameOverMenu.SetActive(true);
        }
    }

    public void ReturnMainMenu() {
        SceneManager.LoadScene("MainMenu");
        gameOver = false;
    }
}
