using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSupplyPassiveItem : PassiveItem
{
    protected override void ApplyModifier() {
        if(ps.CurrentNumOfHearts == ps.playerData.MaxHealth) {
            PlayerStats.CurrentHealth += 1;
            return;
        }
        PlayerStats.CurrentHealth += 1;
        ps.CurrentNumOfHearts += 1;
    }
}
