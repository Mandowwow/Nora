using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PassiveItemScriptableObject", menuName = "ScriptableObjects/Passive Item")]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField] int _multiplier;
    [SerializeField] int _level;
    [SerializeField] GameObject _nextLevelPrefab;
    [SerializeField] GameObject _previusLevelPrefab;
    [SerializeField] GameObject _controller;
    [SerializeField] PassiveItemScriptableObject _nextData;
    [SerializeField] Sprite _icon;
    [SerializeField] string _name;
    [SerializeField] string _description;

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

    public GameObject PreviousLevelController
    {
        get => _previusLevelPrefab;
        set => _previusLevelPrefab = value;
    }

    public GameObject Controller
    {
        get => _controller;
        set => _controller = value;
    }

    public PassiveItemScriptableObject NextData
    {
        get => _nextData;
        set => _nextData = value;
    }

    public Sprite Icon
    {
        get => _icon;
        set => _icon = value;
    }

    public string Name
    {
        get => _name;
        private set => _name = value;
    }

    public string Description
    {
        get => _description;
        private set => _description = value;
    }
}
