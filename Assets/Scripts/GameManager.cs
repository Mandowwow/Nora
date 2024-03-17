using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton pattern
    public static GameManager instance;
    public enum GameState {
        Gameplay,
        Paused,
        GameOver,
        LevelUp
    }

    public GameState currentState;

    public GameState previousState;

    public bool isGameOver = false;

    public bool choosingUpgrade;

    //Refrence to the player
    public GameObject playerObject;
    //Refrence Button Manager
    public Button_Manager bm;

    //Singleton objects in the scene
    public GameObject singleton1 = null;
    public GameObject singleton2 = null;
    public GameObject singleton3 = null;

    private void Awake() {

        if(instance == null) {
            instance = this;
        } else {
            Debug.LogWarning("Extra " + this + " Deleted");
            Destroy(gameObject);
        }

        DisableScreens();
    }

    [Header("UI")]
    public GameObject pauseMenuUI;
    public GameObject resultsScreenUI;
    public GameObject levelUpUI;

    private void Start() {
        //bm = GameObject.FindObjectOfType<Button_Manager>();
    }

    private void Update() {
        switch (currentState) {

            case GameState.Gameplay:
                CheckForPauseAndResume();
                break;

            case GameState.Paused:
                CheckForPauseAndResume();
                break;

            case GameState.GameOver:
                if (!isGameOver) {
                    isGameOver = true;
                    Time.timeScale = 0f;
                    Debug.Log("Game Over!");
                    DisplayResults();
                }
                break;
            case GameState.LevelUp:
                if (!choosingUpgrade) {
                    choosingUpgrade = true;
                    Time.timeScale = 0f;
                    Debug.Log("Choosing Upgrades!");
                    levelUpUI.SetActive(true);

                }
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
        resultsScreenUI.SetActive(false);
        levelUpUI.SetActive(false);
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
        Destroy(singleton1.gameObject);
        Destroy(singleton2.gameObject);
        Destroy(singleton3.gameObject);
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().StopMusic("Theme");
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }

    public void GameOver() {
        ChangeState(GameState.GameOver);
        ShowMouse();
    }

    void DisplayResults() {
        resultsScreenUI.SetActive(true);
    }

    public void StartLevelUp() {
        //bm.InitializeButtonNames();
        ChangeState(GameState.LevelUp);
        ShowMouse();
        //playerObject.SendMessage("RemoveAndApplyUpgrades");
    }

    public void EndLevelUp() {
        //bm.InitializeButtonNames();
        choosingUpgrade = false;
        Time.timeScale = 1f;
        levelUpUI.SetActive(false);
        HideMouse();
        ChangeState(GameState.Gameplay);
    }
}
