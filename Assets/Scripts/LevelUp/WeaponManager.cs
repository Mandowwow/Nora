using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWeapon(GameObject weapon) {
        GameObject spawnedWeapon = Instantiate(weapon, pos.transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
    }
}
