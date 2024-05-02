using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MeleeWeaponBehaviour
{
    [SerializeField] private float bulletCooldown;
    private float currentCooldown = 0f;

    protected override void Start() {
        base.Start();
        currentCooldown = bulletCooldown;
    }

    public void Shoot() {
        GameObject spawnedBullet = Instantiate(weaponData.Prefab);
        spawnedBullet.transform.position = transform.position;
    }

    private void ProjectileShoot() {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f) {
            Shoot();
            currentCooldown = bulletCooldown;
        }
    }

    void Update() {
        transform.Rotate(Vector3.forward, 48 * Time.deltaTime);
        ProjectileShoot();
    }
}
