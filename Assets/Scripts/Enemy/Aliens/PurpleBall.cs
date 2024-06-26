﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
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
