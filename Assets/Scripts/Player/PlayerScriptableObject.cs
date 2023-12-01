using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerScriptableObject", menuName ="ScriptableObjects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField] int _maxHealth;
    [SerializeField] int _numOfHearts;
    [SerializeField] float _moveSpeed;
    
    public int MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }

    public int NumOfHearts
    {
        get => _numOfHearts;
        set => _numOfHearts = value;
    }

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }

}
