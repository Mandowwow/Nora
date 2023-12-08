using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        Gameplay,
        Paused,
        GameOver
    }

    public GameState currentState;

    public GameState previousState;

    private void Awake() {
        DisableScreens();
    }
    [Header("UI")]
    public GameObject pauseMenuUI;

    private void Update() {
        switch (currentState) {
            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;
            case GameState.Paused:
                CheckForPauseAndResume();
                break;
            case GameState.GameOver:
                break;
            default:
                Debug.LogWarning("Invalid State!");
                break;
        }
    }

    public void ChangeState(GameState newState) {
        currentState = newState;
    }

    public void PauseGame() {
        if(currentState != GameState.Paused) {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
        }
    }

    public void ResumeGame() {
        if(currentState == GameState.Paused) {
            ChangeState(previousState); //this is to make sure to go back to wherever we were in the game while we paused. because you can pause from many different states of the game.
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
    }

    void CheckForPauseAndResume() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(currentState == GameState.Paused) {
                ResumeGame();
                HideMouse();
            } else {
                PauseGame();
                ShowMouse();
            }
        }
    }

    void DisableScreens() {
        pauseMenuUI.SetActive(false);
    }

    static public void ShowMouse() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    static public void HideMouse() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().StopMusic("Theme");
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }
}
