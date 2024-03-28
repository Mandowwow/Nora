using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeController : WeaponsController
{
    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
    }

    protected override void Attack() {
        base.Attack();
        int direction = Random.Range(0, 4);
        switch (direction) {
            case 0:
                Shoot(Quaternion.Euler(0, 0, 45) * Vector3.down);
                break;
            case 1:
                Shoot(Quaternion.Euler(0, 0, -45) * Vector3.up);
                break;
            case 2:
                Shoot(Quaternion.Euler(0, 0, 45) * Vector3.up);
                break;
            case 3:
                Shoot(Quaternion.Euler(0, 0, -45) * Vector3.down);
                break;
        }

    }

    void Shoot(Vector3 dir) {
        GameObject spawnedBlade = Instantiate(weaponData.Prefab);
        spawnedBlade.transform.position = transform.position;
        spawnedBlade.GetComponent<SawBladeBehaviour>().DirectionCalc(dir);
    }
}
