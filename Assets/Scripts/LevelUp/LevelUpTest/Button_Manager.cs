using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button_Manager : MonoBehaviour {
    public List<Button> buttons;
    public List<WeaponScritpableObject> UpgradeOptions;
    public List<WeaponScritpableObject> availableOptions;

    public List<PassiveItemScriptableObject> PassiveItemUpgradeOptions;
    public List<PassiveItemScriptableObject> PassiveItemAvailableOptions;

    List<int> numbers = new List<int>();
    List<int> numbersItem = new List<int>();

    public GameObject player;
    private PlayerStats ps;
    public GameObject playerPos;

    //Reference Inventory
    public Inventory inventory;

    private void Awake() {
        ps = FindObjectOfType<PlayerStats>();
    }

    void Start() {
        // Initialize the available options list
        availableOptions = new List<WeaponScritpableObject>(UpgradeOptions);
        PassiveItemAvailableOptions = new List<PassiveItemScriptableObject>(PassiveItemUpgradeOptions);
        InitializeButtonNames();
    }

    // Method to initialize button names
    public void InitializeButtonNames() {
        numbers = PopulateLists(availableOptions);
        numbersItem = PopulateLists(PassiveItemAvailableOptions);
        ShuffleArray(numbers);
        ShuffleArray(numbersItem);
        Debug.Log(numbers.Count);
        Debug.Log(numbersItem.Count);

        // Iterate over each button
        for (int i = 0; i < buttons.Count; i++) {
            int index = numbers[i];
            int indexItem = numbersItem[i];

            if (GenerateRandomBoolean()) {

                PassiveItemScriptableObject selectedOption = PassiveItemAvailableOptions[indexItem];

                var textComponents = buttons[i].GetComponentsInChildren<TextMeshProUGUI>();

                // Assign the name of the selected WeaponScriptableObject to the text of the button
                textComponents[0].text = selectedOption.Name;
                textComponents[1].text = selectedOption.Description;

                //Assign the image of the selected Button
                buttons[i].image.sprite = selectedOption.Icon;

                // Assign a method to the button's onClick event
                buttons[i].onClick.RemoveAllListeners();

                buttons[i].onClick.AddListener(() => SpawnItem(selectedOption.Controller));

                //PassiveItemAvailableOptions.RemoveAt(0);

                ReplenishAvailableOptions();
                
            } else {

                // Get the randomly selected WeaponScriptableObject
                WeaponScritpableObject selectedOption = availableOptions[index];

                var textComponents = buttons[i].GetComponentsInChildren<TextMeshProUGUI>();

                // Assign the name of the selected WeaponScriptableObject to the text of the button
                textComponents[0].text = selectedOption.Name;
                textComponents[1].text = selectedOption.Description;

                //Assign the image of the selected Button
                buttons[i].image.sprite = selectedOption.Icon;

                // Assign a method to the button's onClick event
                buttons[i].onClick.RemoveAllListeners();

                if (selectedOption.Level == 1) {
                    buttons[i].onClick.AddListener(() => SpawnWeapon(selectedOption.Controller));
                } else if (selectedOption.Level > 1) {
                    buttons[i].onClick.AddListener(() => ReplaceController(selectedOption.PreviousLevelController, selectedOption.Controller));
                    buttons[i].onClick.AddListener(() => SpawnNewWeaponLevel(selectedOption.Controller));
                }
                // Add the assignment of NextData as a listener to the button's onClick event
                buttons[i].onClick.AddListener(() => AssignNextData(selectedOption, index));

                // Remove the selected option from available options to avoid selecting it again
                availableOptions.RemoveAt(index);


                //Debug.Log(randomIndex);

                if (inventory.AllSlotsFilled()) {
                    UpgradeOptions.Clear();
                    foreach (var item in inventory.weaponInventory) {
                        WeaponsController weaponsController = item.GetComponent<WeaponsController>();
                        WeaponScritpableObject weaponScritpableObject = weaponsController.nextWeaponData;
                        if (weaponScritpableObject != null) {
                            UpgradeOptions.Add(weaponScritpableObject);
                        }
                    }
                }

                ReplenishAvailableOptions();
            }
        }
    }

    void ReplenishAvailableOptions() {
        availableOptions = new List<WeaponScritpableObject>(UpgradeOptions);
    }

    void ReplenishPassiveItemAvailableOptions() {
        PassiveItemAvailableOptions = new List<PassiveItemScriptableObject>(PassiveItemUpgradeOptions);
    }

    void AssignNextData(WeaponScritpableObject selectedOption, int index) {
        if (selectedOption.NextData != null) {
            UpgradeOptions[index] = selectedOption.NextData;
        }
        GameManager.instance.EndLevelUp();
        InitializeButtonNames();
    }

    public void SpawnWeapon(GameObject weapon) {
        if (inventory.AllSlotsFilled() == false) {
            GameObject spawnedWeapon = Instantiate(weapon, playerPos.transform.position, Quaternion.identity);
            spawnedWeapon.transform.SetParent(player.transform);
            inventory.AddWeaponToInventory(spawnedWeapon);
        }
    }

    public void SpawnNewWeaponLevel(GameObject weapon) {
        GameObject spawnedWeapon = Instantiate(weapon, playerPos.transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(player.transform);
    }

    public void SpawnItem(GameObject weapon) {
        GameObject spawnedWeapon = Instantiate(weapon, playerPos.transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(player.transform);
        GameManager.instance.EndLevelUp();
        InitializeButtonNames();
    }

    void ReplaceController(GameObject data, GameObject weapon) {
        inventory.ReplaceWeaponInventory(data, weapon);
        inventory.ReplaceWeaponPlayer(weapon);
    }

    bool GenerateRandomBoolean() {
        // Generate a random integer (0 or 1)
        int randomNumber = Random.Range(0, 2);

        // Return true if randomNumber is 1, false otherwise
        return randomNumber == 1;
    }


    void ShuffleArray(List<int> list) {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            int temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    List<int> PopulateLists<T>(List<T> sourceList) {
        List<int> result = new List<int>();

        for(int i = 0; i<sourceList.Count; i++) {
            result.Add(i);
        }
        return result;
    }
}