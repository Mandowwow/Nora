using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : Enemy
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject smallCell;
    protected override void ChasePlayer() {
        base.ChasePlayer();
        Vector3 playerPos = player.transform.position;

        Vector2 direction = new Vector2(
            playerPos.x - transform.position.x,
            playerPos.y - transform.position.y);
        transform.up = direction;
    }

    protected override void Dying() {
        if (health <= 0) {
            Destroy(this.gameObject);
            //playerPoints += 1;
            RandomDrop();
            Debug.Log(FindEnemies.Enemies.Count);
            FindEnemies.Enemies.Remove(this.gameObject);
        }
        Instantiate(smallCell, spawn.transform.position, Quaternion.identity);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
