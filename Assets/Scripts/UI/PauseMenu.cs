using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
                HideMouse();
            } else {
                Pause();
                ShowMouse();
            }
        }
    }

    public void Resume() {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        HideMouse();
    }

    void Pause() {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    void ShowMouse() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideMouse() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
