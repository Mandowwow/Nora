 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for all projectiles behaviour scripts to inherit
/// </summary>
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScritpableObject weaponData;

    protected Animator anim;
    protected Rigidbody2D rb;
    protected Vector3 direction;
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
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionCalc(Vector3 dir) {
        direction = dir;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage(currentDamage);
        } else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }
}
