using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Two_Shockwave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(2);
        }
    }
    public void Destroy() {
        Destroy(this.gameObject);
    }
}
