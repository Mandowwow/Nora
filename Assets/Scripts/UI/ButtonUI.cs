﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class ButtonUI : MonoBehaviour
{
    public GameObject firstMenuButton;
    public string[] musicNames;
    public void NewGameButton() {
        FindObjectOfType<AudioManager>().StopMusic("MainMenu");
        Invoke("StartGame", 1f);
    }

    private void Start() {
        //clear selected eventsystem object
        EventSystem.current.SetSelectedGameObject(null);
        //set new eventsystem object
        EventSystem.current.SetSelectedGameObject(firstMenuButton);    
    }

    private void StartGame() {
        SceneManager.LoadScene("Dungeon");
        CharacterStats.NumOfHearts = 3;
        CharacterStats.Health = 6;
        CharacterStats.Shield = false;
        CharacterStats.BulletSpeed = 6;
        CharacterStats.PlayerSpeed = 0.1f;
        CharacterStats.CurrentWeapon = CharacterStats.Weapon.Gun;
        CharacterStats.FireRate = 0.6f;
        FindEnemies.Enemies.Clear();
        LevelGeneration.PlayerPoints = 0;
        LevelGeneration.FirstLevel = true;

        int rand = Random.Range(0, 3);
        FindObjectOfType<AudioManager>().Play(musicNames[rand]);
    }
}
