using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveController : WeaponsController
{
    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    protected override void Attack() {
        base.Attack();
        GameObject spawnedWave = Instantiate(weaponData.Prefab);
        spawnedWave.transform.position = transform.position;
    }
}
