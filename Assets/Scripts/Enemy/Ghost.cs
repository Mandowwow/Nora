using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    private SpriteRenderer sp;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackRange;

    protected override void Start() {
        base.Start();
        sp = GetComponent<SpriteRenderer>();
    }
    protected override void ChasePlayer() { 
        if (Vector2.Distance(transform.position, player.position) < 12 && Vector2.Distance(transform.position, player.position) > attackRange) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        TurnDirection();
    }

    protected override void Attack() {
        if (Vector2.Distance(transform.position, player.position) < attackRange && Time.time > nextFire) {
            DealDmg();
        }
    }

    private void DealDmg() {
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(transform.position, 1, playerLayer);
        for (int i = 0; i < playerToDamage.Length; i++) {
            playerToDamage[i].GetComponentInParent<Health>().TakeDamage(1);
        }
        nextFire = Time.time + fireRate;
    }

    private void TurnDirection() {
        if(transform.position.x > player.transform.position.x) {
            sp.flipX = false;
        } else {
            sp.flipX = true;
        }
    }

}
