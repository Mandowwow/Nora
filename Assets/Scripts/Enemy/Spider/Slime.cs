using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private static float nextFire = 0f;
    private static float fireRate = 0.5f; 
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
