using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : ProjectileWeaponBehaviour {
    protected override void Start() {
        base.Start();
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(Damage());
        if (collision.GetComponent<Enemy>()) {
            collision.GetComponent<Enemy>().TakeDamage(currentDamage);
        }
    }

    private IEnumerator Damage() {
        col.enabled = false;
        yield return new WaitForSeconds(0.25f);
        col.enabled = true;
    }
}
