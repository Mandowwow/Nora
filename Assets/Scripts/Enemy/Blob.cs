using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : Enemy
{
    private Vector2 randPos;
    private float randTime;
    private bool canMove = true;
    [SerializeField] private GameObject bullet;

    protected override void Start() {
        base.Start();
        randTime = Random.Range(1f, 3f);
        randPos = new Vector2(Random.Range(-6.4f, 6.4f), Random.Range(-3.5f, 3f));
    }
    protected override void ChasePlayer() {
        if(Vector2.Distance(transform.position, randPos) > 0) {
            transform.position = Vector2.MoveTowards(transform.position, randPos, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, randPos) == 0 && canMove == true) {
            StartCoroutine(Wait());
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
    protected override void Dying() {
        base.Dying();
        if(health <= 0) {
            BlowUp();
        }
    }
    private void BlowUp() {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    private IEnumerator Wait() {
        canMove = false;
        Debug.Log("Waiting " + randTime);
        yield return new WaitForSeconds(randTime);
        randPos = new Vector2(Random.Range(-6.4f, 6.4f), Random.Range(-3.5f, 3f));
        randTime = Random.Range(1f, 3f);
        canMove = true;
    }
}
