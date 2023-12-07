using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PassiveItemScriptableObject", menuName = "ScriptableObjects/Passive Item")]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField] int _multiplier;
    [SerializeField] int _level;
    [SerializeField] GameObject _nextLevelPrefab;
    [SerializeField] Sprite _icon;

    public int Multiplier
    {
        get => _multiplier;
        set => _multiplier = value;
    }

    public int Level
    {
        get => _level;
        set => _level = value;
    }

    public GameObject NextLevelPrefab
    {
        get => _nextLevelPrefab;
        set => _nextLevelPrefab = value;
    }

    public Sprite Icon
    {
        get => _icon;
        set => _icon = value;
    }
}
