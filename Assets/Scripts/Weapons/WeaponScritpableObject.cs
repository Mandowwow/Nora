using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScritpableObject : ScriptableObject {
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject _controller;
    [SerializeField] WeaponScritpableObject _nextData;
    [SerializeField] int _damage;
    [SerializeField] float _speed;
    [SerializeField] float _cooldownDuration;
    [SerializeField] int _pierce;
    [SerializeField] int _level;
    [SerializeField] GameObject _nextLevelPrefab;
    [SerializeField] GameObject _previousLevelController;
    [SerializeField] Sprite _icon;
    [SerializeField] string _name;
    [SerializeField] string _description;

    public GameObject Prefab
    {
        get => _prefab;
        set => _prefab = value;
    }

    public GameObject Controller
    {
        get => _controller;
        set => _controller = value;
    }
    public WeaponScritpableObject NextData
    {
        get => _nextData;
        set => _nextData = value;
    }

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public float CooldownDuration
    {
        get => _cooldownDuration;
        set => _cooldownDuration = value;
    }

    public int Pierce
    {
        get => _pierce;
        set => _pierce = value;
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
        get => _previousLevelController;
        set => _previousLevelController = value;
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

    public void OnButtonClick() {
        Debug.Log(Name);
    }
}
