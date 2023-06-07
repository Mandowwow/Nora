using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private static int health = 6;
    [SerializeField] private static int numOfHearts = 3;
    [SerializeField] private static bool shield = false;
    [SerializeField] private static float bulletSpeed = 6;
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

    public static int NumOfHearts
    {
        get => numOfHearts;
        set => numOfHearts = value;
    }

    public static float BulletSpeed
    {
        get => bulletSpeed;
        set => bulletSpeed = value;
    }
}
