using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public enum Weapon {
        Gun,
        Lazer,
        Slime,
        Bat
    }
    private static Weapon currentWeapon = CharacterStats.Weapon.Lazer;
    [SerializeField] private static int health = 6;
    [SerializeField] private static int numOfHearts = 3;
    [SerializeField] private static bool shield = false;
    [SerializeField] private static float bulletSpeed = 6;
    [SerializeField] private static float fireRate = 0.6f;
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
    public static Weapon CurrentWeapon
    {
        get => currentWeapon;
        set => currentWeapon = value;
    }
    public static float FireRate
    {
        get => fireRate;
        set => fireRate = value;
    }
}
