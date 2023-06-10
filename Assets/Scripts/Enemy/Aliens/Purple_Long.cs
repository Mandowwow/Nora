using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_Long : Enemy
{
    [SerializeField] private GameObject spit;
    [SerializeField] private GameObject barrel;
    protected override void ChasePlayer() {
        if (Vector2.Distance(transform.position, player.position) < 12 && Vector2.Distance(transform.position, player.position) > 5f) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        TurnDirection();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
    private void TurnDirection() {
        if (transform.position.x > player.transform.position.x) {
            sprite.flipX = true;
        }
        else {
            sprite.flipX = false;
        }
    }

    public void Spit() {
        if (Vector2.Distance(transform.position, player.position) < 5f) {
            Instantiate(spit, barrel.transform.position, Quaternion.identity);
        }
    }
}
