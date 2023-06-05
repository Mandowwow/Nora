using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private static int health = 6;
    [SerializeField] private int numOfHearts;
    [SerializeField] private static bool shield = false;
    public static int Health
    {
        get => health;
        set => health = value;
    }
    public static bool Shield
    {
        get => shield;
        set => shield = value;
    }

    public int NumOfHearts => numOfHearts;

}
