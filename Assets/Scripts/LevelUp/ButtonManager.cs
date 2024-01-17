using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public List<ButtonInfo> buttoninfoList;
    Button button;

    private static HashSet<int> assignedIndices = new HashSet<int>();

    void Start()
    {
        button = GetComponent<Button>();

        ButtonInfo randomButtonInfo = GetRandomButtonInfo();

        SetupButton(button, randomButtonInfo);
    }

    ButtonInfo GetRandomButtonInfo() {
        if (buttoninfoList.Count > 0) {
            // Keep trying to get a random index until an unassigned one is found
            int randomIndex;
            do {
                randomIndex = Random.Range(0, buttoninfoList.Count);
            } while (assignedIndices.Contains(randomIndex));

            // Add the index to the set of assigned indices
            assignedIndices.Add(randomIndex);

            return buttoninfoList[randomIndex];
        }
        else {
            Debug.LogError("No ButtonInfo objects in the list.");
            return null;
        }
    }

    public void SetupButton(Button button, ButtonInfo buttonInfo) {
        //buttonInfo.OnButtonClick();
        var textComponents = button.GetComponentsInChildren<TextMeshProUGUI>();
        button.image.sprite = buttonInfo.ButtonImage;
        textComponents[0].text = buttonInfo.ButtonName;
        textComponents[1].text = buttonInfo.ButtonDescription;
        button.onClick.AddListener(() => buttonInfo.OnButtonClick());
    }
}
