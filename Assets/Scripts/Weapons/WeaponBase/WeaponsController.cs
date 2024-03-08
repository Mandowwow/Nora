using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weapon Script for all weapons controllers to inherit
/// </summary>
public class WeaponsController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScritpableObject weaponData;
    public WeaponScritpableObject nextWeaponData;
    float currentCooldown;

        


    protected Rigidbody2D rb;

    virtual protected void Start() {
        currentCooldown = weaponData.CooldownDuration; //Weapons not to immediately fire when scene starts; 
    }

    virtual protected void Update() {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f) {
            //once the cooldown has reached 0 then trigger attack
            Attack();
        }
    }

    virtual protected void Attack() {
        currentCooldown = weaponData.CooldownDuration;
    }
}
