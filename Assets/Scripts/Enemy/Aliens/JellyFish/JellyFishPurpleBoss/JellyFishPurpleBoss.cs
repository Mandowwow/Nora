using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishPurpleBoss : Enemy
{
    [SerializeField]
    GameObject prefabExplosion;
    [SerializeField]
    GameObject prefabBeam;
    [SerializeField]
    Transform beamPos;
    Vector3 targetPosition = new Vector2(-6f,0f);

    float timer = 0f;
    float timer2 = 0f;
    float interval = 2f;
    protected override void ChasePlayer() {
        if(Health >= 30) {
        } else {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-6f,0f,0f), speed * Time.fixedDeltaTime);
        }
        TurnDirection();
    }

    protected override void Start() {
        base.Start();
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
        if(Health >= 0) {
            timer += Time.deltaTime;
            if(timer >= interval) {
                Explosion();
                timer = 0f;
            }
        }

        if(Health <= 30) {
            timer2 += Time.deltaTime;
            if(timer2 >= interval) {
                Beam();
                timer2 = -18f;
            }
        }
    }

    void Explosion() {
        GameObject spawnedPrefab = Instantiate(prefabExplosion);
        spawnedPrefab.transform.position = player.position;
    }

    void Beam() {       
        GameObject spawnedPrefab = Instantiate(prefabBeam);
        spawnedPrefab.transform.position = beamPos.position;       
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
