using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSupplyPassiveItem : PassiveItem
{
    protected override void ApplyModifier() {
        ps.CurrentNumOfHearts += passiveItemData.Multiplier;
    }
}
