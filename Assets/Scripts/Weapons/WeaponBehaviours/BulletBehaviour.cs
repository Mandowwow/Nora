using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : ProjectileWeaponBehaviour
{
    protected override void Start() {
        base.Start();
        rb.velocity = direction * currentSpeed;
        FindObjectOfType<AudioManager>().Play("GunShot");
    }

    protected override void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage(currentDamage);
            ReducePierceBullet();
        }
        else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }

    public void ReducePierceBullet() {
        currentPierce--;
        if (currentPierce <= 0) {
            GetComponent<Collider2D>().enabled = false;
            gameObject.transform.localScale += new Vector3(0.2f, 0.2f);
            anim.Play("Impact");
            rb.velocity = new Vector2(0, 0);
            Destroy(this.gameObject, 0.3f);

        }
    }
}
