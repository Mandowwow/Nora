using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weapon Script for all weapons to inherit
/// </summary>
public class WeaponsController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public int damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    protected Rigidbody2D rb;

    virtual protected void Start() {
        currentCooldown = cooldownDuration; //Weapons not to immediately fire when scene starts; 
    }

    virtual protected void Update() {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f) {
            //once the cooldown has reached 0 then trigger attack
            Attack();
        }
    }

    virtual protected void Attack() {
        currentCooldown = cooldownDuration;
    }
}
