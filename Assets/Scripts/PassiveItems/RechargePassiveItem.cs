using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePassiveItem : PassiveItem
{
    protected override void ApplyModifier() {
        while(PlayerStats.CurrentHealth != ps.CurrentNumOfHearts) {
            PlayerStats.CurrentHealth += 1;
        }
    }
}
