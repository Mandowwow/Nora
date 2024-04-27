using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public Animator anim;
    public float speed;
    private GameObject target;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
            //Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            //Destroy(this.gameObject);
        }
    }
}
