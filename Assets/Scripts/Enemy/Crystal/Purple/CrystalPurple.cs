using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPurple : Enemy
{
    [SerializeField]
    GameObject prefab = null;
    protected override void Start() {
        base.Start();
        speed = Random.Range(1.25f, 1.75f);
    }
    protected override void ChasePlayer() {
        base.ChasePlayer();
        TurnDirection();
    }
    protected override void Dying() {
        if (health <= 0) {
            BlowUp();
            Destroy(this.gameObject);
            FindEnemies.Enemies.Remove(this.gameObject);
            if (FindEnemies.Enemies.Count <= 0) {
                Instantiate(findEnemies.Portal, new Vector3(0, 0, 0), Quaternion.identity);
                GameManager.instance.StartLevelUp();
            }
        }
    }
    private void BlowUp() {
        GameObject spawnedBullet = Instantiate(prefab);
        spawnedBullet.transform.position = transform.position;
    }
    private void TurnDirection() {
        if (player != null) {
            if (transform.position.x > player.transform.position.x) {
                sprite.flipX = false;
            }
            else {
                sprite.flipX = true;
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
