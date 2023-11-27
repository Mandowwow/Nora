using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : ProjectileWeaponBehaviour
{
    BulletController bc;

    protected override void Start() {
        base.Start();
        bc = FindObjectOfType<BulletController>();
        rb.velocity = direction * bc.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage(1);
            GetComponent<Collider2D>().enabled = false;
            gameObject.transform.localScale += new Vector3(0.2f, 0.2f);
            anim.Play("Impact");
            rb.velocity = new Vector2(0, 0);
            Destroy(this.gameObject, 0.3f);
        }
        else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }
}
