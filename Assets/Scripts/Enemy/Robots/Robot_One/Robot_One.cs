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

    //Wander Variables
    private bool moveLeft = true;

    protected override void Start() {
        base.Start();
        InvokeRepeating("Shoot", 3f, 0.5f);
    }
    protected override void ChasePlayer() {
        if(Health <= 40) {
            Wander();
        }
        else if(Vector2.Distance(transform.position, player.position) < 20 && Vector2.Distance(transform.position, player.position) > 6f) {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * Time.fixedDeltaTime * speed);
        }
    }

    protected override void Dying() {
        base.Dying();
        if (Health <= 0) {
            GameObject[] ball = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in ball) {
                GameObject.Destroy(obj);
            }
        }
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if(Health == 40) {
            SpawnDrone();
            CheckMovement();
        } else if (Health == 30) {
            CheckMovement();
        } else if (Health == 20) {
            CheckMovement();
        } else if (Health == 10) {
            CheckMovement();
        }
    }

    private void Wander() {
        if (moveLeft) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-5f, 0f), speed * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(5f, 0f), speed * Time.deltaTime);
        }
    }

    private void CheckMovement() {
        if (transform.position.x > 0f) {
            moveLeft = true;
        }
        else {
            moveLeft = false;
        }
    }

    private void Shoot() {
        if(Health > 40) {
            GameObject spawnedBullet = Instantiate(bulletPrefab);
            spawnedBullet.transform.position = barrel.transform.position;

        }
    }

    private void SpawnDrone() {
        foreach (var item in orbPos) {
            GameObject spawnedDrone = Instantiate(dronePrefab);
            spawnedDrone.transform.position = item.transform.position;

        }
    }
}
