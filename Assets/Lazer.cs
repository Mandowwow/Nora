using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private static float nextFire = 0f;
    private static float fireRate = 0.25f;
    void Update()
    {
        Destroy(this.gameObject, 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
