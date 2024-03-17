using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Refrences
    public PlayerScriptableObject playerData;

    //Player instantiate pos
    public GameObject pos;

    //current Stats
    static int _currentHealth;
    float _currentMoveSpeed;
    int _currentNumOfHearts;

    #region Current Stat Properties
    public static int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public int CurrentNumOfHearts
    {
        get => _currentNumOfHearts;
        set => _currentNumOfHearts = value;
    }

    public float CurrentMoveSpeed
    {
        get => _currentMoveSpeed;
        set => _currentMoveSpeed = value;
    }
    #endregion

    private void Awake() {

        //assign variables from scriptable object to player
        if(_currentHealth == 0) {
            _currentHealth = playerData.MaxHealth;
        }
        _currentMoveSpeed = playerData.MoveSpeed;
        _currentNumOfHearts = playerData.NumOfHearts;
    
    }
}
