using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : WeaponsController
{
    private SpriteRenderer render;
    protected override void Start() {
        base.Start();
        GameObject player = GameObject.FindWithTag("Controller");
        render = player.GetComponent<SpriteRenderer>();
    }

    protected override void Attack() {
        if (Input.GetKey("right")) {
            Shoot(new Vector3(0f, 0f, 0f));
        }
        else if (Input.GetKey("left")) {
            Shoot(new Vector3(0f, 0f, 180f));
        }
        else if (Input.GetKey("up")) {
            Shoot(new Vector3(0f, 0f, 90f));
        }
        else if (Input.GetKey("down")) {
            Shoot(new Vector3(0f, 0f, -90f));

        }
    }

    void Shoot(Vector3 dir) {
        base.Attack();
        GameObject spawnedBullet = Instantiate(weaponData.Prefab);
        spawnedBullet.transform.position = transform.position;
        //spawnedBullet.GetComponent<LaserBehaviour>().DirectionCalc(dir);
        spawnedBullet.transform.rotation = Quaternion.Euler(dir);
        spawnedBullet.transform.parent = transform;
        StartCoroutine(RevertLayer());
    }

    private IEnumerator RevertLayer() {
        render.sortingOrder = -1;
        yield return new WaitForSeconds(0.5f);
        render.sortingOrder = 20;
    }
}
