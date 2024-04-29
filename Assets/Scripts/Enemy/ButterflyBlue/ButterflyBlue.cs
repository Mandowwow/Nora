using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBlue : Enemy
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject charge;
    [SerializeField] private GameObject[] randPos;
    private int rand = 0;

    protected override void Start() {
        base.Start();
        randPos = GameObject.FindGameObjectsWithTag("RandPos");
        rand = Random.Range(0, randPos.Length);
        InvokeRepeating("DealDmg", 0f, 1f);
    }

    protected override void ChasePlayer() {
        if (Health <= 29) {
            HandleMovement();
        }
    }

    private void DealDmg() {
        StartCoroutine(Spawn());
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if (Health == 29) {
            rand = Random.Range(0, randPos.Length);
        }
        else if (Health == 20) {
            rand = Random.Range(0, randPos.Length);
        }
        else if (Health == 10) {
            rand = Random.Range(0, randPos.Length);
        }
    }

    private void HandleMovement() {
        transform.position = Vector3.MoveTowards(transform.position, randPos[rand].transform.position, speed * Time.fixedDeltaTime);
    }

    private IEnumerator Spawn() {
        if(Health <= 30) {
            GameObject spawnedCharge = Instantiate(charge);
            spawnedCharge.transform.position = barrel.transform.position;
            spawnedCharge.transform.parent = transform;
            yield return new WaitForSeconds(0.5f);
            Instantiate(ball, barrel.transform.position, Quaternion.identity);
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

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
