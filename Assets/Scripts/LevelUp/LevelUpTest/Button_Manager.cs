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

    int[] numbers = new int[] { 0, 1, 2, 3};
    int[] numbersItem = new int[] { 0, 1 };

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
        ShuffleArray(numbers);

        // Iterate over each button
        for (int i = 0; i < buttons.Count; i++) {
            int index = numbers[i];

            if (GenerateRandomBoolean()) {
                if (GenerateRandomBoolean()) {
                    PassiveItemScriptableObject selectedOption = PassiveItemAvailableOptions[0];

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

                } else {
                    PassiveItemScriptableObject selectedOption = PassiveItemAvailableOptions[1];

                    var textComponents = buttons[i].GetComponentsInChildren<TextMeshProUGUI>();

                    // Assign the name of the selected WeaponScriptableObject to the text of the button
                    textComponents[0].text = selectedOption.Name;
                    textComponents[1].text = selectedOption.Description;

                    //Assign the image of the selected Button
                    buttons[i].image.sprite = selectedOption.Icon;

                    // Assign a method to the button's onClick event
                    buttons[i].onClick.RemoveAllListeners();

                    buttons[i].onClick.AddListener(() => SpawnItem(selectedOption.Controller));

                    //PassiveItemAvailableOptions.RemoveAt(1);

                }
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
                }
                // Add the assignment of NextData as a listener to the button's onClick event
                buttons[i].onClick.AddListener(() => AssignNextData(selectedOption, index));

                // Remove the selected option from available options to avoid selecting it again
                availableOptions.RemoveAt(index);


                //Debug.Log(randomIndex);
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
        InitializeButtonNames();
    }

    public void SpawnWeapon(GameObject weapon) {
        if (inventory.AllSlotsFilled() == false) {
            GameObject spawnedWeapon = Instantiate(weapon, playerPos.transform.position, Quaternion.identity);
            spawnedWeapon.transform.SetParent(player.transform);
            inventory.AddWeaponToInventory(spawnedWeapon);
        }
    }

    public void SpawnItem(GameObject weapon) {
        GameObject spawnedWeapon = Instantiate(weapon, playerPos.transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(player.transform);
        GameManager.instance.EndLevelUp();
        InitializeButtonNames();
        InitializeButtonNames();
    }

    void ReplaceController(GameObject data, GameObject weapon) {
        inventory.ReplaceWeapon(data, weapon);
    }

    bool GenerateRandomBoolean() {
        // Generate a random integer (0 or 1)
        int randomNumber = Random.Range(0, 2);
        Debug.Log(randomNumber);

        // Return true if randomNumber is 1, false otherwise
        return randomNumber == 1;
    }


    void ShuffleArray(int[] array) {
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            int temp = array[k];
            array[k] = array[n];
            array[n] = temp;
        }
    }
}