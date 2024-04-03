using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishPurpleBoss : Enemy
{
    [SerializeField]
    GameObject prefabExplosion;
    Vector3 targetPosition = new Vector2(-6f,0f);

    float timer = 0f;
    float interval = 2f;
    protected override void ChasePlayer() {
        if(Health >= 30) {
            TurnDirection();
        } else {
            // Calculate the direction towards the target position
            Vector2 direction = (targetPosition - transform.position);

            // Calculate the velocity change needed to reach the target position
            Vector2 velocityChange = Vector2.MoveTowards(rb.velocity, direction.normalized * speed, speed * Time.fixedDeltaTime) - rb.velocity;

            // Apply the velocity change using Rigidbody2D's MovePosition method
            rb.MovePosition(rb.position + velocityChange * Time.fixedDeltaTime);
        }
        //base.ChasePlayer();
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

    protected override void Attack() {
        if(Health >= 30) {
            timer += Time.deltaTime;
            if(timer >= interval) {
                Explosion();
                timer = 0f;
            }
        }
    }

    void Explosion() {
        GameObject spawnedPrefab = Instantiate(prefabExplosion);
        spawnedPrefab.transform.position = player.position;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
