using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    [SerializeField] private GameObject slime;
    private float instantiateRate = 0f;
    private float nextInstantiate = 0.2f;

    protected override void Start() {
        base.Start();
        sprite.color = Color.white;
        InvokeRepeating("DealDmg", instantiateRate, nextInstantiate);
    }

    protected override void Attack() {
        LookAtPlayer();   
    }

    private void DealDmg() {
        Instantiate(slime, transform.position, Quaternion.identity);
    }

    protected override void Dying() {
        base.Dying();
        if(Health <= 0) {
            GameObject[] slime = GameObject.FindGameObjectsWithTag("Slime");
            foreach(GameObject obj in slime) {
                GameObject.Destroy(obj);
            }
        }
    }

    private void LookAtPlayer() {
        Vector3 playerPos = player.transform.position;

        Vector2 direction = new Vector2(
            playerPos.x - transform.position.x,
            playerPos.y - transform.position.y);
        transform.up = direction.normalized;
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
