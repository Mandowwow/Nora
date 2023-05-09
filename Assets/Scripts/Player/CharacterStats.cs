using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private static int health = 6;
    [SerializeField] private int numOfHearts;

    public static int Health
    {
        get => health;
        set => health = value;
    }

    public int NumOfHearts => numOfHearts;

}
