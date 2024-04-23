using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBehaviour : ProjectileWeaponBehaviour
{
    BatController bc;
    protected override void Start() {
        base.Start();
        FindObjectOfType<AudioManager>().Play("Rocket");
        bc = FindObjectOfType<BatController>();
        bc.FindClosestEnemy(this.GetComponent<Rigidbody2D>(), transform);
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage(currentDamage);
            Impact();
        }
        else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }

    public void Impact() {
        currentPierce--;
        if (currentPierce <= 0) {
            GetComponent<Collider2D>().enabled = false;
            gameObject.transform.localScale -= new Vector3(0.5f, 0.5f);
            gameObject.transform.localRotation = Quaternion.identity;
            anim.Play("Impact");
            rb.velocity = new Vector2(0, 0);
            Destroy(this.gameObject, 0.3f);

        }
    }

}
