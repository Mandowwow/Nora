using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Two : Enemy
{
    [SerializeField] GameObject sawBladePrefab;
    int[] angles = new int[2] { 45, -45 };
    int[] directions = new int[2] { -1, 1 };
    int randomAngleValue;
    int randomDirValue;

    protected override void Start() {
        base.Start();
        InvokeRepeating("SpawnSawBlade", 5f, 8f);
    }

    void SpawnSawBlade() {
        randomAngleValue = Random.Range(0, 2);
        randomDirValue = Random.Range(0, 2);
        SawBlades(Quaternion.Euler(0, 0, angles[randomAngleValue]) * new Vector3(0, directions[randomDirValue], 0));
    }

    void SawBlades(Vector3 dir) {
        GameObject spanwedPrefab = Instantiate(sawBladePrefab);
        spanwedPrefab.transform.position = transform.position;
        spanwedPrefab.GetComponent<Robot_Two_SawBladeBehaviour>().DirectionCalc(dir);
    }
}
