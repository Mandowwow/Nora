using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    private Vector2 randPos;
    private float randTime;
    private float speed = 0.5f;
    [SerializeField] private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        randTime = Random.Range(1f, 3f);
        randPos = new Vector2(Random.Range(-6.6f, 6.6f), Random.Range(-2.05f, 2.05f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, randPos) > 0.1) {
            transform.position = Vector2.MoveTowards(transform.position, randPos, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, randPos) <= 0.1 && canMove == true) {
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait() {
        canMove = false;
        yield return new WaitForSeconds(randTime);
        randPos = new Vector2(Random.Range(-6.6f, 6.6f), Random.Range(-2.05f, 2.05f));
        randTime = Random.Range(1f, 3f);
        canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Vector3 moveDirection = collision.gameObject.GetComponentInParent<Rigidbody2D>().transform.position - transform.position;
            collision.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(-moveDirection.normalized * -0.065f);
        }
    }
}
