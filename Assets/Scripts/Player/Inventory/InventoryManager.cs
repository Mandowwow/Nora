using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponsController> weaponSlots = new List<WeaponsController>(3);
    public int[] weaponLevels = new int[6];
    public List<Image> weaponUISlots = new List<Image>(3);
    public List<PassiveItem> passiveItemSlots = new List<PassiveItem>(3);
    public int[] passiveItemLevels = new int[6];
    public List<Image> passiveItemUISlots = new List<Image>(3);

    [System.Serializable]
    public class WeaponUpgrade {

        public int weaponUpgradeIndex;
        public GameObject initialWeapon;
        public WeaponScritpableObject weaponData;
    }

    [System.Serializable]
    public class PassiveItemUpgrade {

        public int passiveItemUpgradeIndex;
        public GameObject initialPassiveItem;
        public PassiveItemScriptableObject passiveItemData;
    }

    [System.Serializable]
    public class UpgradeUI {

        public TextMeshProUGUI upgradeNameDisplay;
        public TextMeshProUGUI upgradeDescriptionDisplay;
        public Image upgradeIcon;
        public Button upgradeButton;
    }

    public List<WeaponUpgrade> weaponUpgradeOptions = new List<WeaponUpgrade>();
    public List<PassiveItemUpgrade> passiveItemUpgradeOptions = new List<PassiveItemUpgrade>();
    public List<UpgradeUI> upgradeUIOptions = new List<UpgradeUI>();

    //Refrences
    PlayerStats player;

    private void Start() {
        player = GetComponent<PlayerStats>();
    }

    public void AddWeapon(int slotIndex, WeaponsController weapon) {
        weaponSlots[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.weaponData.Level;
        weaponUISlots[slotIndex].enabled = true;
        weaponUISlots[slotIndex].sprite = weapon.weaponData.Icon;
        
        if(GameManager.instance != null && GameManager.instance.choosingUpgrade) {
            GameManager.instance.EndLevelUp();
        }
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem) {
        passiveItemSlots[slotIndex] = passiveItem;
        passiveItemLevels[slotIndex] = passiveItem.passiveItemData.Level;
        passiveItemUISlots[slotIndex].enabled = true;
        passiveItemUISlots[slotIndex].sprite = passiveItem.passiveItemData.Icon;

        if (GameManager.instance != null && GameManager.instance.choosingUpgrade) {
            GameManager.instance.EndLevelUp();
        }
    }

    public void LevelUpWeapon(int slotIndex, int upgradeIndex) {
        if(weaponSlots.Count > slotIndex) {
            WeaponsController weapon = weaponSlots[slotIndex];
            if (!weapon.weaponData.NextLevelPrefab) {
                Debug.LogError("No next level for " + weapon);
                return;
            }
            GameObject upgradedWeapon = Instantiate(weapon.weaponData.NextLevelPrefab, player.pos.transform.position, Quaternion.identity);
            upgradedWeapon.transform.SetParent(transform);
            AddWeapon(slotIndex, upgradedWeapon.GetComponent<WeaponsController>());
            Destroy(weapon.gameObject);
            weaponLevels[slotIndex] = upgradedWeapon.GetComponent<WeaponsController>().weaponData.Level;

            weaponUpgradeOptions[upgradeIndex].weaponData = upgradedWeapon.GetComponent<WeaponsController>().weaponData;

            if (GameManager.instance != null && GameManager.instance.choosingUpgrade) {
                GameManager.instance.EndLevelUp();
            }
        }
    }

    public void LevelUpPassiveItem(int slotIndex, int upgradeIndex) {
        if (passiveItemSlots.Count > slotIndex) {
            PassiveItem passiveItem = passiveItemSlots[slotIndex];
            if (!passiveItem.passiveItemData.NextLevelPrefab) {
                Debug.LogError("No next level for " + passiveItem);
                return;
            }
            GameObject upgradedPassiveItem = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position, Quaternion.identity);
            upgradedPassiveItem.transform.SetParent(transform);
            AddPassiveItem(slotIndex, upgradedPassiveItem.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            passiveItemLevels[slotIndex] = upgradedPassiveItem.GetComponent<PassiveItem>().passiveItemData.Level;

            passiveItemUpgradeOptions[upgradeIndex].passiveItemData = upgradedPassiveItem.GetComponent<PassiveItem>().passiveItemData; 

            if (GameManager.instance != null && GameManager.instance.choosingUpgrade) {
                GameManager.instance.EndLevelUp();
            }
        }
    }

    void ApplyUpgradeOptions() {

        List<WeaponUpgrade> availableWeaponUpgrades = new List<WeaponUpgrade>(weaponUpgradeOptions);
        List<PassiveItemUpgrade> availablePassiveItemUpgrades = new List<PassiveItemUpgrade>(passiveItemUpgradeOptions);
        
        foreach(var upgradeOption in upgradeUIOptions) {

            if(availableWeaponUpgrades.Count == 0 && availablePassiveItemUpgrades.Count == 0) {
                return;
            }

            int upgradeType;

            if(availableWeaponUpgrades.Count == 0) {
                upgradeType = 2;
            } else if(availablePassiveItemUpgrades.Count == 0) {
                upgradeType = 1;
            } else {
                upgradeType = Random.Range(1, 3);
            }

            if(upgradeType == 1) {
                WeaponUpgrade chosenWeaponUpgrade = availableWeaponUpgrades[Random.Range(0, availableWeaponUpgrades.Count)];

                availableWeaponUpgrades.Remove(chosenWeaponUpgrade);

                if(chosenWeaponUpgrade != null) {
                    bool newWeapon = false;

                    for (int i = 0; i < weaponSlots.Count; i++) {                       
                        if(weaponSlots[i] != null && weaponSlots[i].weaponData == chosenWeaponUpgrade.weaponData) {
                            newWeapon = false;

                            if (!newWeapon) {

                                if (!chosenWeaponUpgrade.weaponData.NextLevelPrefab) {
                                    break;
                                }

                                upgradeOption.upgradeButton.onClick.AddListener(() => LevelUpWeapon(i, chosenWeaponUpgrade.weaponUpgradeIndex)); //Apply button funcionality
                                //Set description and name for the next level of the weapon.
                                upgradeOption.upgradeDescriptionDisplay.text = chosenWeaponUpgrade.weaponData.NextLevelPrefab.GetComponent<WeaponsController>().weaponData.Description;
                                upgradeOption.upgradeNameDisplay.text = chosenWeaponUpgrade.weaponData.NextLevelPrefab.GetComponent<WeaponsController>().weaponData.Name;
                            }
                            break;
                        } else {
                            newWeapon = true;
                        }
                    }

                    if (newWeapon) {
                        upgradeOption.upgradeButton.onClick.AddListener(() => player.SpawnWeapon(chosenWeaponUpgrade.initialWeapon));
                        upgradeOption.upgradeDescriptionDisplay.text = chosenWeaponUpgrade.weaponData.Description;
                        upgradeOption.upgradeNameDisplay.text = chosenWeaponUpgrade.weaponData.Name;
                    }

                    upgradeOption.upgradeIcon.sprite = chosenWeaponUpgrade.weaponData.Icon;
                }
            } else if(upgradeType == 2) {
                PassiveItemUpgrade chosenPassiveItemUpgrade = availablePassiveItemUpgrades[Random.Range(0, availablePassiveItemUpgrades.Count)];

                availablePassiveItemUpgrades.Remove(chosenPassiveItemUpgrade);

                if(chosenPassiveItemUpgrade != null) {
                    bool newPassiveItem = false;

                    for (int i = 0; i < passiveItemSlots.Count; i++) {
                        if(passiveItemSlots[i] != null && passiveItemSlots[i].passiveItemData == chosenPassiveItemUpgrade.passiveItemData) {
                            newPassiveItem = false;

                            if (!newPassiveItem) {

                                if (!chosenPassiveItemUpgrade.passiveItemData.NextLevelPrefab) {
                                    break;
                                }

                                upgradeOption.upgradeButton.onClick.AddListener(() => LevelUpPassiveItem(i, chosenPassiveItemUpgrade.passiveItemUpgradeIndex)); //if item is not new, level up the current item chosen
                                upgradeOption.upgradeDescriptionDisplay.text = chosenPassiveItemUpgrade.passiveItemData.NextLevelPrefab.GetComponent<PassiveItem>().passiveItemData.Description;
                                upgradeOption.upgradeNameDisplay.text = chosenPassiveItemUpgrade.passiveItemData.NextLevelPrefab.GetComponent<PassiveItem>().passiveItemData.Name;
                            }
                            break;
                        } else {
                            newPassiveItem = true;
                        }

                    }

                    if (newPassiveItem) {
                        upgradeOption.upgradeButton.onClick.AddListener(() => player.SpawnPassiveItems(chosenPassiveItemUpgrade.initialPassiveItem));
                        upgradeOption.upgradeDescriptionDisplay.text = chosenPassiveItemUpgrade.passiveItemData.Description;
                        upgradeOption.upgradeNameDisplay.text = chosenPassiveItemUpgrade.passiveItemData.Name;
                    }

                    upgradeOption.upgradeIcon.sprite = chosenPassiveItemUpgrade.passiveItemData.Icon;
                }
            }
        }

    }

    void RemoveUpgradeOption() {
        foreach (var upgradeOption in upgradeUIOptions) {
            upgradeOption.upgradeButton.onClick.RemoveAllListeners();
        }
    }

    public void RemoveAndApplyUpgrades() {
        RemoveUpgradeOption();
        ApplyUpgradeOptions();
    }

    /// <summary>
    /// Trying to get my weapons to spawn every scene
    /// </summary>

    //public static List<WeaponsController> CurrentWeaponsList = new List<WeaponsController>();
    //public void SpawnAllWeapons() {
    //    foreach (var weapon in weaponSlots) {
    //        CurrentWeaponsList.Add(weapon);
    //        Debug.LogWarning(CurrentWeaponsList.Count);
    //    }
    //    for (int i = 0; i < CurrentWeaponsList.Count; i++) {
    //        player.SpawnWeapon();
    //        Debug.Log("Tried");
    //    }


    //}
}
