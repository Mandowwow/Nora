using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_LongBall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Shoot();
        StartCoroutine(Wait());
    }

    private void Shoot() {
        Vector3 targetPos = target.transform.position;
        Vector2 direction = new Vector2(
            targetPos.x - transform.position.x,
            targetPos.y - transform.position.y);
        //transform.up = direction;
        rb.velocity = direction.normalized * speed;
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }
}
