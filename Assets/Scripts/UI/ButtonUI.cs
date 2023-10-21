using System.Collections;
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
        CharacterStats.NumOfHearts = 5;
        CharacterStats.Health = 6;
        CharacterStats.Shield = false;
        CharacterStats.BulletSpeed = 6;
        CharacterStats.CurrentWeapon = CharacterStats.Weapon.Gun;
        CharacterStats.FireRate = 0.6f;
        AbilityController.state = AbilityController.State.Inactive;
        FindEnemies.Enemies.Clear();
        LevelGeneration.PlayerPoints = 0;
        LevelGeneration.FirstLevel = true;
    }
}
