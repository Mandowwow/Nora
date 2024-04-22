using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    //singleton pattern
    public static GameManager instance;

    public GameObject pauseFirstButton, levelUpFirstButton;
    private GameObject previouslySelectedObject;
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
        HandleSelectionChange();

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

            //clear selected eventsystem object
            EventSystem.current.SetSelectedGameObject(null);
            //set new eventsystem object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
    }

    public void ResumeGame() {
        if(currentState == GameState.Paused) {
            ChangeState(previousState); //this is to make sure to go back to wherever we were in the game while we paused. because you can pause from many different states of the game.
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            HideMouse();
        }
    }

    void CheckForPauseAndResume() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7")) {
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
        PlayerPrefs.SetInt("CurrentIndex", 0);
        PlayerPrefs.Save(); // Save PlayerPrefs data immediately
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().StopMusic(AudioManager.lastSongPlayed);
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
        ChangeState(GameState.LevelUp);
        ShowMouse();
        //clear selected eventsystem object
        EventSystem.current.SetSelectedGameObject(null);
        //set new eventsystem object
        EventSystem.current.SetSelectedGameObject(levelUpFirstButton);
        // Access the highlight object from the selected GameObject
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
    }

    public void EndLevelUp() {
        //bm.InitializeButtonNames();
        choosingUpgrade = false;
        Time.timeScale = 1f;
        levelUpUI.SetActive(false);
        HideMouse();
        ChangeState(GameState.Gameplay);
    }

    public void HandleSelectionChange() {
        // Get the currently selected object from EventSystem
        GameObject newSelectedObject = EventSystem.current.currentSelectedGameObject;

        if (previouslySelectedObject != null) {
            // Deactivate the highlight of the previously selected object, if any
            Transform previousHighlight = previouslySelectedObject.transform.Find("Highlight");
            if (previousHighlight != null) {
                previousHighlight.gameObject.SetActive(false);
            }
        }

        // Store the new selected object as the previously selected object
        previouslySelectedObject = newSelectedObject;

        if (newSelectedObject != null) {
            // Activate the highlight of the newly selected object, if any
            Transform highlight = newSelectedObject.transform.Find("Highlight");
            if (highlight != null) {
                highlight.gameObject.SetActive(true);
            }
        }
    }
}
