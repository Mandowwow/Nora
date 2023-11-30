using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : WeaponsController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack() {
        base.Attack();
        Vector2 randPos = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-3f, 0.75f));
        GameObject spawnedPortal = Instantiate(weaponData.Prefab);
        spawnedPortal.transform.position = randPos;
    }

    public void FindClosestEnemy(Rigidbody2D rb, Vector3 vector) {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach (Enemy currentEnemy in allEnemies) {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy) {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        if(closestEnemy!= null) {
            Vector3 targetPos = closestEnemy.transform.position;
            Vector2 direction = new Vector2(
                targetPos.x - vector.x,
                targetPos.y - vector.y);
            rb.velocity = direction.normalized * weaponData.Speed;
        }
    }

}
