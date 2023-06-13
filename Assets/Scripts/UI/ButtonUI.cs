﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public void NewGameButton() {
        Invoke("StartGame", 1f);
    }
    
    private void StartGame() {
        SceneManager.LoadScene("Dungeon");
        CharacterStats.NumOfHearts = 3;
        CharacterStats.Health = 6;
        CharacterStats.Shield = false;
        AbilityController.state = AbilityController.State.Inactive;
        CharacterStats.BulletSpeed = 6;
        FindEnemies.Enemies.Clear();
    }
}
