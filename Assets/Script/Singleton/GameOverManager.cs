using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Script.AssetsScripts.Enum;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public Text gameOverText;

    public bool gameOver;

    public static GameOverManager _instance;

    void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
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
        gameOverMenu.SetActive(false);
        gameOver = false;
    }

    public void SetGameOver(bool state, Team player)
    {
        gameOver = state;

        if (gameOver)
        {
            gameOverText.text = "Player " + ((int)player + 1).ToString() + " Win !";
            gameOverMenu.SetActive(true);
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        gameOver = false;
    }
}
