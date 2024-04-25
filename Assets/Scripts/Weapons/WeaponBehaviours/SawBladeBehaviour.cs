using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeBehaviour : ProjectileWeaponBehaviour
{
    Vector3 lastVelocity;
    protected override void Start() {
        base.Start();
        FindObjectOfType<AudioManager>().Play("Sawblade");
        rb.velocity = direction * currentSpeed;
    }

    private void Update() {
        transform.Rotate(new Vector3(0f, 0f, 396f) * Time.deltaTime);
    }
    private void FixedUpdate() {
        lastVelocity = rb.velocity;
    }
    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage(currentDamage);
            ReducePierceBullet();
        }
        else if (collision.CompareTag("Wall")) {
            Vector2 collisionNormal = collision.ClosestPoint(transform.position) - (Vector2)transform.position;
            float speed = lastVelocity.magnitude;
            collisionNormal.Normalize();
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collisionNormal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }

    public void ReducePierceBullet() {
        currentPierce--;
        if (currentPierce <= 0) {
            Destroy(this.gameObject);
        }
    }
}
