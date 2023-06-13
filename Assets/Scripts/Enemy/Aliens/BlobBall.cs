using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 0f;
    private Vector2[] angles =  new Vector2[] {new Vector2(1,0), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(0, 1)};

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        int rand = Random.Range(0, 4);
        //Vector2 direction = new Vector2(-1, 0);
        //rb.velocity = direction.normalized * speed;
        rb.velocity = angles[rand] * speed;
        StartCoroutine(Wait());
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

    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
