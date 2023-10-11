using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{   
    //Music
    public AudioSource source;
    public AudioSource source2;
    public AudioClip clip;
    public AudioClip clip2;
    //
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
        //source.GetComponent<AudioSource>().UnPause();
        //source2.GetComponent<AudioSource>().Pause();
    }

    void Pause() {
        pauseMenuUi.SetActive(true);
        //source.GetComponent<AudioSource>().Pause();
        Time.timeScale = 0f;
        gameIsPaused = true;
        source2.PlayOneShot(clip);
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    static public void ShowMouse() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    static public void HideMouse() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
