using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_One_DroneBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletCooldown;
    [SerializeField] private GameObject bulletPrefab;
    private float currentCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = bulletCooldown;
    }
    public void Shoot() {
        GameObject spawnedBullet = Instantiate(bulletPrefab);
        spawnedBullet.transform.position = transform.position;
        spawnedBullet.GetComponent<Robot_One_DroneBulletBehaviour>().BulletTarget = this.gameObject;
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
