using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 1 * 10 * Time.deltaTime, 0) ;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }
}
