using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : WeaponsController
{
    protected override void Start() {
        base.Start();
    }

    protected override void Attack() {
        if (Input.GetKey("right") || Input.GetKey("joystick button 1")) {
            Shoot(new Vector3(1f, 0f, 0f));
        } else if (Input.GetKey("left") || Input.GetKey("joystick button 2")) {
            Shoot(new Vector3(-1f, 0f, 0f));
        } else if (Input.GetKey("up") || Input.GetKey("joystick button 3")) {
            Shoot(new Vector3(0f, 1f, 0f));
        } else if (Input.GetKey("down") || Input.GetKey("joystick button 0")) {
            Shoot(new Vector3(0f, -1f, 0f));

        }
    }

    void Shoot(Vector3 dir) {
        base.Attack();
        GameObject spawnedBullet = Instantiate(weaponData.Prefab);
        spawnedBullet.transform.position = transform.position;
        spawnedBullet.GetComponent<BulletBehaviour>().DirectionCalc(dir);

    }
}
