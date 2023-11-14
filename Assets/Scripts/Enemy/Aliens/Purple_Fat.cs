using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_Fat : Enemy
{
    [SerializeField] GameObject barrel = null;
    [SerializeField] GameObject barrel2 = null;
    [SerializeField] GameObject barrel3 = null;
    [SerializeField] GameObject barrel4 = null;
    [SerializeField] GameObject bullet = null;
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

    protected override void Dying() {
        if (health <= 0) {
            BlowUp();
            Destroy(this.gameObject);
            FindEnemies.Enemies.Remove(this.gameObject);
            if (FindEnemies.Enemies.Count <= 0) {
                Instantiate(findEnemies.Portal, new Vector3(0, 0, 0), Quaternion.identity);
                //LevelUp();
            }

        }
    }

    private void BlowUp() {
        Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        Instantiate(bullet, barrel2.transform.position, barrel2.transform.rotation);
        Instantiate(bullet, barrel3.transform.position, barrel3.transform.rotation);
        Instantiate(bullet, barrel4.transform.position, barrel4.transform.rotation);
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
