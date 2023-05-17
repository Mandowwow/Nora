using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : Enemy
{
    [SerializeField] private GameObject beam;
    [SerializeField] private GameObject gun;
    protected override void Start() {
        base.Start();
        sprite.color = Color.white;
        InvokeRepeating("DealDmg", 1f, 0.25f);
    }


    protected override void DealDmg() {
        Instantiate(beam, gun.transform.position, Quaternion.identity);
    }

    protected override void ChasePlayer() {
        if(Health <= 30) {
            base.ChasePlayer();
            CancelInvoke();
        }
    }

    protected override IEnumerator Change() {
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
