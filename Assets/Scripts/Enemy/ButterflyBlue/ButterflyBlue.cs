﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBlue : Enemy
{
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
