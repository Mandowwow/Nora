using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    private SpriteRenderer sp;

    protected override void Start() {
        base.Start();
        sp = GetComponent<SpriteRenderer>();
    }
    protected override void ChasePlayer() {
        base.ChasePlayer();
        TurnDirection();
    }

    private void TurnDirection() {
        if(transform.position.x > player.transform.position.x) {
            sp.flipX = false;
        } else {
            sp.flipX = true;
        }
    }
}
