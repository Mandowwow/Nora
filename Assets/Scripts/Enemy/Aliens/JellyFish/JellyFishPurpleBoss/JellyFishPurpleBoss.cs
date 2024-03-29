using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishPurpleBoss : Enemy
{
    protected override void ChasePlayer() {
        base.ChasePlayer();
        TurnDirection();
    }

    private void TurnDirection() {
        if (player != null) {
            if (transform.position.x > player.transform.position.x) {
                sprite.flipX = true;
            }
            else {
                sprite.flipX = false;
            }
        }
    }
}
