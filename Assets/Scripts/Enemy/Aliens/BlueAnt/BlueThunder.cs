using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueThunder : MonoBehaviour
{
    private Transform player = null;
    [SerializeField] private float speed = 2f;
    private Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Destroy(this.gameObject, 20f);
    }

    private void FixedUpdate() {
        ChasePlayer();
    }

    protected virtual void ChasePlayer() {
        if (Vector2.Distance(transform.position, player.position) < 30) {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.GetComponentInParent<Health>()){
            collision.GetComponentInParent<Health>().TakeDamage(1);
        }
    }
}
