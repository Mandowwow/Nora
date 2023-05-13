using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : Enemy
{
    [SerializeField] private GameObject portal;
    private Vector2 randPos;
    private float instantiateRate = 5f;
    private float nextInstantiate = 3f;
    protected override void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerMovement>();
        findEnemies = GameObject.FindGameObjectWithTag("Manager").GetComponent<FindEnemies>();
        sprite = GetComponent<SpriteRenderer>();
        InvokeRepeating("DealDmg", instantiateRate, nextInstantiate);
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
        //DealDmg code
        randPos = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-3f, 0.75f));
        Instantiate(portal, randPos, Quaternion.identity);
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
