using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishPurple : Enemy
{
    private bool canChase = false;
    protected override void Start() {
        Invoke("Shoot", 3f);
        base.Start();
        speed = Random.Range(1f, 1.5f);
    }
    protected override void ChasePlayer() {
        if (canChase) {
            base.ChasePlayer();
        }
        TurnDirection();       
    }
    private void RunAway() {
        if (Vector2.Distance(transform.position, player.position) < 5) {
            TurnDirection();
            Vector3 targetPos = player.position;
            Vector2 direction = new Vector2(
                targetPos.x - transform.position.x,
                targetPos.y - transform.position.y);
            //direction = Quaternion.AngleAxis(45, Vector2.up) * direction;
            rb.MovePosition(rb.position + -direction.normalized * speed * Time.fixedDeltaTime);
        }
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
    private void Shoot() {
        
        canChase = true;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
