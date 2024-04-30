using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBulletBehaviour : ProjectileWeaponBehaviour
{
    [SerializeField] private GameObject bulletTarget;
    protected override void Start() {
        base.Start();
        bulletTarget = GameObject.FindGameObjectWithTag("BeamTarget");
        Shoot();
    }

    private void Shoot() {
        Vector3 targetPos = bulletTarget.transform.position;
        Vector2 direction = new Vector2(
            targetPos.x - transform.position.x,
            targetPos.y - transform.position.y);
        transform.up = direction;
        rb.velocity = direction.normalized * currentSpeed;
    }
}
