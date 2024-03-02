using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    public Transform background;
    public Transform battleGround;

    public bool startCinematic;

    public GameObject settingsWindow;

    public Canvas menu;

    public void StartGame() {
        startCinematic = true;
        menu.enabled = false;
    }

    public void SettingsButton() {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow() {
        settingsWindow.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void gameEntranceCinematic() {
        if (background.position.y < 3.5f) {
            //background.position = new Vector3(background.position.x, background.position.y + 0.0005f, background.position.z);
            background.transform.Translate(Vector3.up * Time.deltaTime * 1f);
        }
        
        if (battleGround.position.y < -1.5f) {
            //battleGround.position = new Vector3(battleGround.position.x, battleGround.position.y + 0.0015f, battleGround.position.z);
            battleGround.transform.Translate(Vector3.up * Time.deltaTime * 3f);
        }

        if (background.position.y >= 3.5f && battleGround.position.y >= -1.5f) {
            startCinematic = false;
            SceneManager.LoadScene("BattleScene");
            background.position = new Vector3(background.position.x, 3.5f, background.position.z);
            battleGround.position = new Vector3(battleGround.position.x, -1.5f, battleGround.position.z);
        }
    }

    void Start() {
        background.position = new Vector3(background.position.x, 0f, background.position.z);
        battleGround.position = new Vector3(battleGround.position.x, -12f, battleGround.position.z);
        startCinematic = false;
        menu.enabled = true;
    }

    void Update() {
        if (startCinematic) {
            gameEntranceCinematic();
        }
    } 
}
