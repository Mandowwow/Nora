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

    //Player instantiate pos
    public GameObject pos;

    //current Stats
    static int _currentHealth;
    float _currentMoveSpeed;
    int _currentNumOfHearts;

    public GameObject firstPassiveItemTest, secondPassiveItemTest;
    public GameObject secondWeaponTest;

    #region Current Stat Properties
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
    #endregion

    private void Awake() {

        inventory = GetComponent<InventoryManager>();

        //assign variables from scriptable object to player
        if(_currentHealth == 0) {
            _currentHealth = playerData.MaxHealth;
        }
        _currentMoveSpeed = playerData.MoveSpeed;
        _currentNumOfHearts = playerData.NumOfHearts;

        //Starting weapon
        //SpawnWeapon(secondWeaponTest);
        SpawnWeapon(playerData.StartingWeapon);
        //inventory.LevelUpWeapon(0);
        //SpawnPassiveItems(firstPassiveItemTest);
        //inventory.LevelUpPassiveItem(0);
        //SpawnPassiveItems(secondPassiveItemTest);
        //inventory.SpawnAllWeapons();
        
    }

    public void SpawnWeapon(GameObject weapon) {

        if(weaponIndex >= inventory.weaponSlots.Count - 1) {
            Debug.LogError("Inventory is full");
            return;
        }
        //Spawn the starting weapon
        Debug.Log("Trying to spawn weapon");
        GameObject spawnedWeapon = Instantiate(weapon, pos.transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponsController>());//Add weapon to inventory slot

        weaponIndex++;//this increment ensures that each weapon is assigned to the next slot in the invetory and prevents overlapping
    }

    public void SpawnPassiveItems(GameObject passiveItem) {

        if (passiveItemIndex >= inventory.passiveItemSlots.Count - 1) {
            Debug.LogError("Inventory is full");
            return;
        }
        //Spawn the starting passive item
        GameObject spawnedPassiveItem = Instantiate(passiveItem, new Vector3(0f, -3.1f), Quaternion.identity);
        spawnedPassiveItem.transform.SetParent(transform);
        inventory.AddPassiveItem(passiveItemIndex, spawnedPassiveItem.GetComponent<PassiveItem>());//Add passive item to inventory slot

        passiveItemIndex++;//this increment ensures that each passive item is assigned to the next slot in the invetory and prevents overlapping
    }
}
