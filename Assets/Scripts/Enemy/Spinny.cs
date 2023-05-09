using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinny : Enemy
{
    Vector3 lastVelocity;
    protected override void Start() {
        base.Start();
        rb.AddForce(new Vector2(250f, 250f));
    }
    protected override void ChasePlayer() {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            float speed = lastVelocity.magnitude;
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }

    }
}
