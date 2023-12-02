using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Refrences
    public PlayerScriptableObject playerData;

    //current Stats
    static int _currentHealth;
    float _currentMoveSpeed;
    int _currentNumOfHearts;

    //Spawned Weapon
    public List<GameObject> spawnedWeapons;

    public static int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public int CurrentNumOfHearts
    {
        get => _currentNumOfHearts;
        set => _currentNumOfHearts = value;
    }

    public float CurrentMoveSpeed
    {
        get => _currentMoveSpeed;
        set => _currentMoveSpeed = value;
    }
    private void Awake() {
        if(_currentHealth == 0) {
            _currentHealth = playerData.MaxHealth;
        }
        _currentMoveSpeed = playerData.MoveSpeed;
        _currentNumOfHearts = playerData.NumOfHearts;

        //Starting weapon
        SpawnWeapon(playerData.StartingWeapon);
    }

    public void SpawnWeapon(GameObject weapon) {
        //Spawn the starting weapon
        GameObject spawnedWeapon = Instantiate(weapon, new Vector3(0f,-3.1f), Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        spawnedWeapons.Add(spawnedWeapon);
    }
}
