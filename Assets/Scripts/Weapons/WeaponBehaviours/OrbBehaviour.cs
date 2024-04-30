using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MeleeWeaponBehaviour
{
    [SerializeField]private float radius = 2f; // Radius of the orbit
    private Transform center;  // The center or pivot point around which to orbit

    private float angle = 0f;

    protected override void Start() {
        //base.Start();
        center = FindObjectOfType<OrbController>().transform;
    }

    public void Shoot() {
        GameObject spawnedBullet = Instantiate(weaponData.Prefab);
        spawnedBullet.transform.position = transform.position;
    }

    void Update() {
        // Calculate the new position based on the orbit parameters
        float x = center.position.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = center.position.y + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        float z = transform.position.z; // Maintain the same z position

        // Set the new position
        transform.position = new Vector3(x, y, z);

        // Increment the angle based on the speed
        angle += 48 * Time.deltaTime;

        // Keep the angle within a 360-degree range
        if (angle >= 360f)
            angle -= 360f;

        transform.Rotate(Vector3.forward, 48 * Time.deltaTime);
    }
}
