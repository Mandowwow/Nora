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
        
        if (Input.GetKey("right") || Input.GetKey("joystick button 1") || Input.GetKey("left") || Input.GetKey("joystick button 2")
            || Input.GetKey("up") || Input.GetKey("joystick button 3") || Input.GetKey("down") || Input.GetKey("joystick button 0")) {
            Shoot();
        }
    }

    void Shoot() {
        base.Attack();
        spanwedOrb.GetComponent<OrbBehaviour>().Shoot();
    }

    private void SpawnOrb() {
        spanwedOrb = Instantiate(orbPrefab);
        spanwedOrb.transform.position = transform.position;
        spanwedOrb.transform.parent = transform.parent;
    }
}
