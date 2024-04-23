using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehaviour : MeleeWeaponBehaviour {

    protected override void Start() {
        base.Start();
        FindObjectOfType<AudioManager>().Play("ElectricWave");
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Enemy>()) {
            collision.GetComponent<Enemy>().TakeDamage(currentDamage);
        }
    }

    public void Destroy() {
        Destroy(this.gameObject);
    }
}
