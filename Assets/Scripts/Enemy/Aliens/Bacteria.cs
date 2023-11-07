using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : Enemy
{

    protected override void Start() {
        base.Start();
        speed = Random.Range(0.75f, 2f);
    }

    protected override void ChasePlayer() {
        base.ChasePlayer();
        Vector3 playerPos = player.transform.position;

        Vector2 direction = new Vector2(
            playerPos.x - transform.position.x,
            playerPos.y - transform.position.y);
        transform.up = direction;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
