using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : ProjectileWeaponBehaviour
{
    BatController bc;
    protected override void Start() {
        base.Start();
        bc = FindObjectOfType<BatController>();
        bc.FindClosestEnemy(this.GetComponent<Rigidbody2D>(), transform);
    }

}
