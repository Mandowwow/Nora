using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MeleeWeaponBehaviour
{
    private static float nextFire = 0f;
    private static float fireRate = 0.5f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponent<Enemy>() && Time.time > nextFire) {
            collision.GetComponent<Enemy>().TakeDamage(currentDamage);
            nextFire = Time.time + fireRate;
        }
    }
}
