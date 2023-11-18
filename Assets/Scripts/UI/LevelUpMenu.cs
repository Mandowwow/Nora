using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject levelUpMenuUi;
    public CharacterStats stats;
    public Button button1, button2;
    public Sprite[] butImgs = null;
    private int rand = 0, rand2 = 0;
    void Update()
    {
        //if (PauseMenu.gameIsPaused == false) {
        //    if (Input.GetKeyDown(KeyCode.Q)) {
        //        OpenMenu();
        //        PauseMenu.ShowMouse();
        //    }
        //}
    }

    private void Start() {
        rand = Random.Range(0, butImgs.Length);
        rand2 = Random.Range(0, butImgs.Length);
        button1.GetComponent<Image>().sprite = butImgs[rand];
        button2.GetComponent<Image>().sprite = butImgs[rand2];
    }

    public void AbilityAdd() {
        switch (rand) {
            case 0:
                Debug.Log("Bullet");
                IncreaseBulletSpeed();
                break;
            case 1:
                Debug.Log("Health");
                IncreaseHealth();
                break;
            case 2:
                Debug.Log("Shield");
                Shield();
                break;
            case 3:
                Debug.Log("Ability 4");
                break;
        }
        
    }

    public void AbilityAdd2() {
        switch (rand2) {
            case 0:
                Debug.Log("Bulet");
                IncreaseBulletSpeed();
                break;
            case 1:
                Debug.Log("Health");
                IncreaseHealth();
                break;
            case 2:
                Debug.Log("Shield");
                Shield();
                break;
            case 3:
                Debug.Log("Ability 4");
                break;
        }

    }

    public void OpenMenu() {
        levelUpMenuUi.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.ShowMouse();
    }

    public void CloseMenu() {
        levelUpMenuUi.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.HideMouse();
    }

    public void IncreaseHealth() {
        CharacterStats.NumOfHearts += 1;
        CharacterStats.Health += 1;
        CloseMenu();
    }

    public void Shield() {
        CharacterStats.Shield = true;
        AbilityController.state = AbilityController.State.Active;
        GameObject player = GameObject.FindGameObjectWithTag("Controller");
        player.transform.GetChild(6).gameObject.SetActive(true);
        CloseMenu();
    }

    public void IncreaseBulletSpeed() {
        CharacterStats.BulletSpeed += 3;
        CloseMenu();
    }
}
