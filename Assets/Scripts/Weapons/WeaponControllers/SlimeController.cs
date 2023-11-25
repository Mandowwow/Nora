using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : WeaponsController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack() {
        base.Attack();
        GameObject spawnedSlime = Instantiate(prefab);
        spawnedSlime.transform.position = transform.position; //Spawn at parent position (which is player)
    }

}
