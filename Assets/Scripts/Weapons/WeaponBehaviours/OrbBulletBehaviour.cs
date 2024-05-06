using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBulletBehaviour : ProjectileWeaponBehaviour
{
    [SerializeField] private GameObject _bulletTarget;
    public GameObject BulletTarget
    {
        set => _bulletTarget = value;
    }

    protected override void Start() {
        base.Start();
        _bulletTarget = GameObject.FindGameObjectWithTag("DroneTarget");
        Shoot();
    }

    private void Shoot() {
        Vector3 targetPos = _bulletTarget.transform.position;
        Vector2 direction = new Vector2(
            targetPos.x - transform.position.x,
            targetPos.y - transform.position.y);
        transform.up = direction;
        rb.velocity = direction.normalized * currentSpeed;
    }
}
