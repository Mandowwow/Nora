using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : Enemy
{
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject wayPoint;
    private Vector2 randPos;
    private float instantiateRate = 3f;
    private float nextInstantiate = 3f;
    protected override void Start() {
        base.Start();
        sprite.color = Color.white;
        InvokeRepeating("DealDmg", instantiateRate, nextInstantiate);
        InvokeRepeating("Charge", instantiateRate, 4.5f);
    }
    protected override void ChasePlayer() {
        Vector3 playerPos = player.transform.position;

        Vector2 direction = new Vector2(
            playerPos.x - transform.position.x,
            playerPos.y - transform.position.y);
        transform.up = direction;
    }

    protected override void Attack() {
        //if enemy is close enough DealDmg()
        //This will run in update()
    }

    protected override void DealDmg() {
        randPos = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-3f, 0.75f));
        Instantiate(portal, randPos, Quaternion.identity);
    }

    private void Charge() {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()  {
        if (Health <= 30) {
            Vector2 randPos2 = new Vector2(Random.Range(-6.4f, 6.4f), Random.Range(-3.35f, 3.35f));
            Instantiate(wayPoint, randPos2, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            transform.position = new Vector2(randPos2.x, randPos2.y);
        }
    }

    protected override IEnumerator Change() {
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }


    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }

}
