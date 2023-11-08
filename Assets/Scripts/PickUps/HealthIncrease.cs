using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            IncreaseHealth();
            Destroy(this.gameObject);
        }
    }
    private void IncreaseHealth() {
        CharacterStats.NumOfHearts += 1;
        CharacterStats.Health += 1;
    }
}
