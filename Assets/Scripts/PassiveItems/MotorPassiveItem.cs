using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorPassiveItem : PassiveItem
{
    protected override void ApplyModifier() {
        //ps.CurrentMoveSpeed *= 1 + passiveItemData.Multiplier / 100f;
        ps.CurrentMoveSpeed += 0.01f;
    }
}
