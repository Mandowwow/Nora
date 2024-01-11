using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : WeaponsController
{
    protected override void Start() {
        base.Start();
    }

    protected override void Attack() {
        if (Input.GetKey("right")) {
            Shoot(new Vector3(1f, 0f, 0f));
        }
        else if (Input.GetKey("left")) {
            Shoot(new Vector3(-1f, 0f, 0f));
        }
        else if (Input.GetKey("up")) {
            Shoot(new Vector3(0f, 1f, 0f));
        }
        else if (Input.GetKey("down")) {
            Shoot(new Vector3(0f, -1f, 0f));

        }
    }

    void Shoot(Vector3 dir) {
        base.Attack();
        GameObject spawnedBullet = Instantiate(weaponData.Prefab);
        spawnedBullet.transform.position = transform.position;
        spawnedBullet.GetComponent<LaserBehaviour>().DirectionCalc(dir);
        //spawnedBullet.transform.rotation = Quaternion.Euler(0,90,0);
        Debug.Log("Here");
    }
}
