using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : Enemy
{
    [SerializeField] private GameObject beam;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject barrel;
    [SerializeField] private GameObject[] randPos;
    private int rand = 0;
    private bool move = false;
    protected override void Start() {
        base.Start();
        sprite.color = Color.white;
        randPos = GameObject.FindGameObjectsWithTag("RandPos");
        rand = Random.Range(0, randPos.Length);
        InvokeRepeating("DealDmg", 1f, 0.20f);
        Debug.Log(randPos.Length);
    }

    private void DealDmg() {
        if(Health >= 30 ) {
            Instantiate(beam, gun.transform.position, Quaternion.identity);
        } else {
            move = true;
            CancelInvoke();
            InvokeRepeating("Ball", 3f, 1f);
        }
    }

    private void Ball() {
        if (Health <= 29) {
            Instantiate(ball, barrel.transform.position, Quaternion.identity);
        }
    }

    protected override void ChasePlayer() {
        if (Health <= 29 && move == true) {
            transform.position = Vector3.MoveTowards(transform.position, randPos[rand].transform.position, speed * Time.deltaTime);
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
