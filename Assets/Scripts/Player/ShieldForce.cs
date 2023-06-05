using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldForce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            Debug.Log("Not wall");
        }
    }
}
