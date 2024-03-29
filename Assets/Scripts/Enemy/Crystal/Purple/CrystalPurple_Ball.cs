using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPurple_Ball : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private GameObject target;
    private Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Wait());
    }
    private void Update() {
        Shoot();
    }
    private void Shoot() {
        Vector3 targetPos = target.transform.position;
        Vector2 direction = new Vector2(
            targetPos.x - transform.position.x,
            targetPos.y - transform.position.y);
        //transform.up = direction;
        rb.velocity = direction.normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
