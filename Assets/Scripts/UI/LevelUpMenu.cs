using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject levelUpMenuUi;
    public CharacterStats stats;

    void Update()
    {
        //if (PauseMenu.gameIsPaused == false) {
        //    if (Input.GetKeyDown(KeyCode.Q)) {
        //        OpenMenu();
        //        PauseMenu.ShowMouse();
        //    }
        //}
       
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
