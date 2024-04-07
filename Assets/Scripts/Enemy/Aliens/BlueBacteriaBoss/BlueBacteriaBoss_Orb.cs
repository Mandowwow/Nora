using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBacteriaBoss_Orb : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    private Vector3 direction = new Vector3(0, 0, 0);
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    public void DirectionCalc(Vector3 dir) {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Wall") || collision.GetComponent<BlueBacteriaBoss>()) {
            Destroy(this.gameObject);
        } 
        if (collision.GetComponentInParent<Health>()) {
            collision.GetComponentInParent<Health>().TakeDamage(1);
        }
    }
}
