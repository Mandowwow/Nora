using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderNormal : Enemy
{
    private Vector2 randPos;
    private float randTime;
    [SerializeField] private bool canMove = true;

    protected override void Start() {
        base.Start();
        randTime = Random.Range(1f, 3f);
        randPos = new Vector2(Random.Range(-7.4f, 7.4f), Random.Range(-3.5f, 3.5f));
    }

    protected override void ChasePlayer() {
        if (Vector2.Distance(transform.position, randPos) > 0.1) {
            transform.position = Vector2.MoveTowards(transform.position, randPos, speed * Time.deltaTime);
            LookAtWayPoint();
        }
        else if (Vector2.Distance(transform.position, randPos) <= 0.1 && canMove == true) {
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait() {
        canMove = false;
        yield return new WaitForSeconds(randTime);
        randPos = new Vector2(Random.Range(-7.4f, 7.4f), Random.Range(-3.5f, 3f));
        randTime = Random.Range(1f, 3f);
        canMove = true;
    }

    void LookAtWayPoint() {
        Vector3 wayPointPos = randPos;

        Vector2 direction = new Vector2(
            transform.position.x - wayPointPos.x,
            transform.position.y - wayPointPos.y);
        transform.up = direction.normalized;
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
