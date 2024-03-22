using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    protected override void ChasePlayer() {
        base.ChasePlayer();
        TurnDirection();
    }

    private void TurnDirection() {
        if (player != null) {
            if (transform.position.x > player.transform.position.x) {
                sprite.flipX = true;
            }
            else {
                sprite.flipX = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
