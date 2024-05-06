using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_One : Enemy
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject dronePrefab;
    [SerializeField] GameObject barrel;

    //Spawning orbs Array
    [SerializeField] GameObject[] orbPos;

    protected override void Start() {
        base.Start();
        InvokeRepeating("Shoot", 1f, 0.5f);
    }
    protected override void ChasePlayer() {
        if (Vector2.Distance(transform.position, player.position) < 20 && Vector2.Distance(transform.position, player.position) > 6f) {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * speed);
        }
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if(Health == 30) {
            SpawnDrone();
        }
    }

    private void Shoot() {
        GameObject spawnedBullet = Instantiate(bulletPrefab);
        spawnedBullet.transform.position = barrel.transform.position;
    }

    private void SpawnDrone() {
        foreach (var item in orbPos) {
            GameObject spawnedDrone = Instantiate(dronePrefab);
            spawnedDrone.transform.position = item.transform.position;

        }
    }
}
