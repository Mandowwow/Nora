using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : Enemy
{
    private Vector2 randPos;
    private float randTime;

    protected override void Start() {
        base.Start();
        randTime = Random.Range(0f, 3f);
        randPos = new Vector2(Random.Range(-6.4f, 6.4f), Random.Range(-3.5f, 3f));
    }

    protected override void ChasePlayer() {
        if(Vector2.Distance(transform.position, randPos) > 0) {
            transform.position = Vector2.MoveTowards(transform.position, randPos, speed * Time.deltaTime);
        } else {
            StartCoroutine(Wait());
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }

    private IEnumerator Wait() {
        yield return new WaitForSeconds(randTime);
        randPos = new Vector2(Random.Range(-6.4f, 6.4f), Random.Range(-3.5f, 3f));
    }
}
