using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if(CharacterStats.Health == CharacterStats.NumOfHearts) {
                return;
            } else {
                CharacterStats.Health += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
