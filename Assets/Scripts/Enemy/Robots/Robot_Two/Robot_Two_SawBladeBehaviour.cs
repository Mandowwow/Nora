using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Two_SawBladeBehaviour : MonoBehaviour
{
    [SerializeField]private float speed = 8f;
    private Vector3 direction;
    private Rigidbody2D rb;
    public float destroyAfterSeconds;
    Vector3 lastVelocity;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void Update() {
        transform.Rotate(new Vector3(0f, 0f, 396f) * Time.deltaTime);
    }
    private void FixedUpdate() {
        lastVelocity = rb.velocity;
    }

    public void DirectionCalc(Vector3 dir) {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
        }
        else if (collision.CompareTag("Wall")) {
            Vector2 collisionNormal = collision.ClosestPoint(transform.position) - (Vector2)transform.position;
            float speed = lastVelocity.magnitude;
            collisionNormal.Normalize();
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collisionNormal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }

}
