using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonInfo", menuName = "ScriptableObjects/ButtonInfo")]
public class ButtonInfo : ScriptableObject
{
    [SerializeField] private string _buttonName;
    [SerializeField] private string _buttonDescription;
    [SerializeField] private Sprite _buttonImage;

    public string ButtonName
    {
        get => _buttonName;
        set => _buttonName = value;
    }

    public string ButtonDescription
    {
        get => _buttonDescription;
        set => _buttonDescription = value;
    }

    public Sprite ButtonImage
    {
        get => _buttonImage;
        set => _buttonImage = value;
    }

    public void OnButtonClick() {
        Debug.Log(ButtonName);
    }


    
}
