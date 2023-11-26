using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPortalBehaviour : MeleeWeaponBehaviour
{
    [SerializeField] GameObject prefab;
    protected override void Start() {
        //base.Start();
    }

    public void Spawn() {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
