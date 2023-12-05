using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponsController> weaponSlots = new List<WeaponsController>(3);
    public int[] weaponLevels = new int[6];
    public List<PassiveItem> passiveItemSlots = new List<PassiveItem>(3);
    public int[] passiveItemLevels = new int[6];

    public void AddWeapon(int slotIndex, WeaponsController weapon) {
        weaponSlots[slotIndex] = weapon;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem) {
        passiveItemSlots[slotIndex] = passiveItem;
    }

    public void LevelUpWeapon(int slotIndex) {

    }

    public void LevelUpPassiveItem(int slotIndex) {

    }
}
