using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBacteriaBoss_Orb : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * -speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        } 
        if (collision.GetComponentInParent<Health>()) {
            collision.GetComponentInParent<Health>().TakeDamage(1);
        }
    }
}
