using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishBeam : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
