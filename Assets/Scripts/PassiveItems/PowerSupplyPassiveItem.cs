using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSupplyPassiveItem : PassiveItem
{
    protected override void ApplyModifier() {
        ps.CurrentNumOfHearts += 1;
        PlayerStats.CurrentHealth += 1;
    }
}
