using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * CharacterStats.BulletSpeed;
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<Enemy>().TakeDamage(1);
            GetComponent<Collider2D>().enabled = false;
            gameObject.transform.localScale += new Vector3(0.2f, 0.2f);
            anim.Play("Impact");
            rb.velocity = new Vector2(0, 0);
            Destroy(this.gameObject, 0.3f);
        } else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }

}
