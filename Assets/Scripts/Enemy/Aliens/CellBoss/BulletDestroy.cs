using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Shoot>()) {
            Destroy(collision.gameObject);
        }
    }
}
