﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject[] weaponInventory;

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

    public void ReplaceWeapon(GameObject data, GameObject weapon) {
        for (int i = 0; i < weaponInventory.Length; i++) {
            Debug.Log(data + " " + weaponInventory[i]);
            if(weaponInventory[i] != null && IsSameType(data, weaponInventory[i])) {
                weaponInventory[i] = weapon;
                Debug.Log("Succesful");
            }
        }
    }

    bool IsSameType(GameObject obj1, GameObject obj2) {
        return obj1.tag == obj2.tag;
    }
}
