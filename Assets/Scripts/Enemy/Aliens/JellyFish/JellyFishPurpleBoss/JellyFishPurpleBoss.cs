using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishPurpleBoss : Enemy
{
    [SerializeField]
    GameObject prefabExplosion;

    float timer = 0f;
    float interval = 2f;
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
