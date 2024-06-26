﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCellBoss : Enemy
{
    private Transform target = null;
    // Start is called before the first frame update
    protected override void Start() {
        target = GameObject.Find("BossCell1").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    protected override void ChasePlayer() {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
        transform.up = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<BossCell>()) {
            Debug.Log("<color=green> Touch! </color>");
            //call explosion function
            collision.gameObject.GetComponent<BossCell>().Explosion();
            Destroy(gameObject);
            //Destroy this object
        }
    }
}
