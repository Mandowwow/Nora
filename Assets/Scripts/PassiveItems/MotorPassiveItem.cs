using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorPassiveItem : PassiveItem
{
    protected override void ApplyModifier() {
        ps.CurrentMoveSpeed *= 1 + passiveItemData.Multiplier / 100f;
    }
}
