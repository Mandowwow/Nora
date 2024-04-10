using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brown_SpitBall : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, 0, 0);
    private Rigidbody2D rb = null;
    [SerializeField]
    private float speed = 0f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        Destroy(this.gameObject, 2f);
    }

    public void DirectionCalc(Vector3 dir) {
        direction = dir;
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
