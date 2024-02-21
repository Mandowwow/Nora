using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public List<WeaponScritpableObject> WeaponList;
    Button button;

    private static HashSet<int> assignedIndices = new HashSet<int>();


    //Refrence to WeaponManager
    private GameObject player;
    private WeaponManager manager;

    void Start()
    {
        player = GameObject.Find("PlayerSprite");
        manager = player.GetComponent<WeaponManager>();

        button = GetComponent<Button>();

        WeaponScritpableObject randomButtonInfo = GetRandomButtonInfo();

        SetupButton(button, randomButtonInfo);
    }

    WeaponScritpableObject GetRandomButtonInfo() {
        if (WeaponList.Count > 0) {
            // Keep trying to get a random index until an unassigned one is found
            int randomIndex;
            do {
                randomIndex = Random.Range(0, WeaponList.Count);
            } while (assignedIndices.Contains(randomIndex));

            // Add the index to the set of assigned indices
            assignedIndices.Add(randomIndex);

            return WeaponList[randomIndex];
        }
        else {
            Debug.LogError("No ButtonInfo objects in the list.");
            return null;
        }
    }

    public void SetupButton(Button button, WeaponScritpableObject buttonInfo) {
        //buttonInfo.OnButtonClick();
        var textComponents = button.GetComponentsInChildren<TextMeshProUGUI>();
        button.image.sprite = buttonInfo.Icon;
        textComponents[0].text = buttonInfo.Name;
        textComponents[1].text = buttonInfo.Description;
        button.onClick.AddListener(() => buttonInfo.OnButtonClick());
        button.onClick.AddListener(() => manager.SpawnWeapon(buttonInfo.Controller));
    }

}
