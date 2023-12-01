using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Refrences
    public PlayerScriptableObject playerData;

    //current Stats
    int currentHealth;
    float currentMoveSpeed;
    int currentNumOfHearts;

    public int CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }

    public int CurrentNumOfHearts
    {
        get => currentNumOfHearts;
        set => currentNumOfHearts = value;
            
    }
    private void Awake() {
        currentHealth = playerData.MaxHealth;
        currentMoveSpeed = playerData.MoveSpeed;
        currentNumOfHearts = playerData.NumOfHearts;
    }
}
