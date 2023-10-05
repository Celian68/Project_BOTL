using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverMenu;

    public bool gameOver;

    void Start()
    {
        gameOver = false;
    }

    public void setGameOver(bool state) {
        gameOver = state;

        if (gameOver) {
            gameOverMenu.SetActive(true);
        }
    }

    public void ReturnMainMenu() {
        gameOverMenu.SetActive(false);
        gameOver = false;
    }
}
