using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Refrences
    public PlayerScriptableObject playerData;
    InventoryManager inventory;

    //inventory variables for weapons and items
    public int weaponIndex;
    public int passiveItemIndex;


    //current Stats
    static int _currentHealth;
    float _currentMoveSpeed;
    int _currentNumOfHearts;

    //Spawned Weapon
    //public List<GameObject> spawnedWeapons;

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

        inventory = GetComponent<InventoryManager>();

        //assign variables from scriptable object to player
        if(_currentHealth == 0) {
            _currentHealth = playerData.MaxHealth;
        }
        _currentMoveSpeed = playerData.MoveSpeed;
        _currentNumOfHearts = playerData.NumOfHearts;

        //Starting weapon
        SpawnWeapon(playerData.StartingWeapon);
    }

    public void SpawnWeapon(GameObject weapon) {

        if(weaponIndex >= inventory.weaponSlots.Count - 1) {
            Debug.LogError("Inventory is full");
            return;
        }
        //Spawn the starting weapon
        GameObject spawnedWeapon = Instantiate(weapon, new Vector3(0f,-3.1f), Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        //spawnedWeapons.Add(spawnedWeapon);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponsController>());//Add weapon to inventory slot

        weaponIndex++;//this increment ensures that each weapon is assigned to the next slot in the invetory and prevents overlapping
    }
}
