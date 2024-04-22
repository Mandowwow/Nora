using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePassiveItem : PassiveItem
{
    protected override void ApplyModifier() {
        //while(PlayerStats.CurrentHealth != ps.CurrentNumOfHearts) {
        //    PlayerStats.CurrentHealth += 1;
        //}

        for (int i = 0; i < 3; i++) {
            if(PlayerStats.CurrentHealth != ps.CurrentNumOfHearts) {
                PlayerStats.CurrentHealth += 1;
            }
        }
    }
}
