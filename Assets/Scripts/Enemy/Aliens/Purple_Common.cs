using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_Common : Enemy
{
    private void FixedUpdate() {
        RunAway();
    }
    private void RunAway() {
        if (Vector2.Distance(transform.position, player.position) < 5) {
            TurnDirection();
            Vector3 targetPos = player.position;
            Vector2 direction = new Vector2(
                targetPos.x - transform.position.x,
                targetPos.y - transform.position.y);
            direction = Quaternion.AngleAxis(45, Vector2.up) * direction;
            rb.MovePosition(rb.position + -direction.normalized * speed * Time.fixedDeltaTime);
        }
    }
    protected override void ChasePlayer() {
        //base.ChasePlayer();
    }
    private void TurnDirection() {
        if (transform.position.x > player.transform.position.x) {
            sprite.flipX = true;
        }
        else {
            sprite.flipX = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
