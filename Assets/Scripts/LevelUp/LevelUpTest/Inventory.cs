using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    public GameObject[] weaponInventory;
    // Start is called before the first frame update
    void Start() {
        //AllSlotsFilled();
    }

    // Update is called once per frame
    void Update() {

    }

    public bool AllSlotsFilled() {
        // Check if any slot is empty (null)
        foreach (GameObject weapon in weaponInventory) {
            if (weapon == null) {
                //if there is an empty slot
                return false;
            }
        }
        //if the inventory is full
        Debug.Log("Your Inventory is full!");
        return true;
    }

    public void AddWeaponToInventory(GameObject weapon) {
        for (int i = 0; i < weaponInventory.Length; i++) {
            if (weaponInventory[i] == null) {
                weaponInventory[i] = weapon;
                break;
            }

        }
    }
}
