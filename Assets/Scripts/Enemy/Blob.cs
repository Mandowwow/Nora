using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : Enemy
{
    protected override void Attack() {
        //base.Attack();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }

    //private void OnCollisionStay2D(Collision2D collision) {
    //    if (collision.collider.gameObject.CompareTag("Player")) {
    //        Vector2 a = player.position;
    //        Vector2 b = transform.position;

    //        Vector2 direction = (a - b).normalized;
    //        Vector2 knockback = direction * 5f;
    //        rb = collision.gameObject.GetComponent<Rigidbody2D>();
    //        //rb.AddForce(knockback);
    //        rb.velocity = new Vector2(knockback.x, knockback.y);
    //    }
    //}
}
