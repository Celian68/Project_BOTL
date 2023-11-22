using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public Text gameOverText;

    public bool gameOver;

    void Start()
    {
        gameOverMenu.SetActive(false);
        gameOver = false;
    }

    public void setGameOver(bool state, int player) {
        gameOver = state;

        if (gameOver) {
            gameOverText.text = "Player " + player.ToString() + " Win !";
            gameOverMenu.SetActive(true);
        }
    }

    public void ReturnMainMenu() {
        SceneManager.LoadScene("MainMenu");
        gameOver = false;
    }
}
