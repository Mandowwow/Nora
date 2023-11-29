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
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

}
