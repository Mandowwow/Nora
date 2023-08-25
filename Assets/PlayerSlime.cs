using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlime : MonoBehaviour
{
    private static float nextFire = 0f;
    private static float fireRate = 0.5f;

    private void Start() {
        Destroy(this.gameObject, 4f);
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponent<Enemy>() && Time.time > nextFire) {
            collision.GetComponent<Enemy>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
