using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : WeaponsController {
    [SerializeField] GameObject orbPrefab;
    GameObject spanwedOrb;
    protected override void Start() {
        base.Start();
        SpawnOrb();
    }

    protected override void Attack() {
        Shoot();
    }

    void Shoot() {
        base.Attack();
        SpawnOrb();
    }

    private void SpawnOrb() {
        spanwedOrb = Instantiate(orbPrefab);
        spanwedOrb.transform.position = transform.position;
    }
}
