using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBlue : Enemy
{
    [SerializeField]
    GameObject prefab;
    protected override void ChasePlayer() {
        base.ChasePlayer();
        TurnDirection();
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
    protected override void Dying() {
        if (health <= 0) {
            BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.down);
            BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.down);
            BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.up);
            BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.up);
            BlowUp(Quaternion.Euler(0,0,0) * Vector3.up);
            BlowUp(Quaternion.Euler(0,0,0) * Vector3.down);
            BlowUp(Quaternion.Euler(0,0,90) * Vector3.up);
            BlowUp(Quaternion.Euler(0,0,90) * Vector3.down);
            Destroy(this.gameObject);
            FindEnemies.Enemies.Remove(this.gameObject);
            if (FindEnemies.Enemies.Count <= 0) {
                Instantiate(findEnemies.Portal, new Vector3(0, 0, 0), Quaternion.identity);
                GameManager.instance.StartLevelUp();
            }

        }
    }
    private void BlowUp(Vector3 dir) {
        GameObject spawnedBullet = Instantiate(prefab);
        spawnedBullet.transform.position = transform.position;
        spawnedBullet.GetComponent<CrystalBlue_Ball>().DirectionCalc(dir);
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
