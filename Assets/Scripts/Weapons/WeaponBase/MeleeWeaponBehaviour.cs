using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For melee prefab weapons to inherit
/// </summary>
public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScritpableObject weaponData;

    public float destroyAfterSeconds;

    //Current stats
    protected int currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    private void Awake() {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

}
