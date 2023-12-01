using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    PlayerStats ps;

    private void Start() {
        ps = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (ps.CurrentHealth == ps.CurrentNumOfHearts) {
                return;
            }
            else {
                ps.CurrentHealth += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
