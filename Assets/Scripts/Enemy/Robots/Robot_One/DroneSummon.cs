using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSummon : MonoBehaviour
{
    [SerializeField] GameObject dronePrefab;
    public void InstantiateDrones() {
        GameObject spawnedDrone = Instantiate(dronePrefab);
        spawnedDrone.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
