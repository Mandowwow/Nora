using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinny : Enemy
{
    Vector3 lastVelocity;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackRange;
    protected override void Start() {
        base.Start();
        rb.AddForce(new Vector2(250f, 250f));
    }
    protected override void ChasePlayer() {
        lastVelocity = rb.velocity;
    }

    protected override void Attack() {
        if(player != null) {
            if (Vector2.Distance(transform.position, player.position) < attackRange && Time.time > nextFire) {
                DealDmg();
            }
        }
    }

    private void DealDmg() {
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(transform.position, 1, playerLayer);
        for (int i = 0; i < playerToDamage.Length; i++) {
            playerToDamage[i].GetComponentInParent<Health>().TakeDamage(1);
        }
        nextFire = Time.time + fireRate;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            float speed = lastVelocity.magnitude;
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }

    }
}
