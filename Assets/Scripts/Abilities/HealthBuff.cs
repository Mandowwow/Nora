using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/HealthBuff")]
public class HealthBuff : AbilityEffect
{
    public int ammount;
    private CharacterStats stats;
    public override void Apply(GameObject target) {
        stats = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharacterStats>();
        if (CharacterStats.Health == CharacterStats.NumOfHearts) {
            return;
        } else {
            CharacterStats.Health += ammount;
        }
    }
}
