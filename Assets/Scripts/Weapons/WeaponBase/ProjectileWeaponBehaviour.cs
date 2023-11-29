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

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionCalc(Vector3 dir) {
        direction = dir;
    }
}
