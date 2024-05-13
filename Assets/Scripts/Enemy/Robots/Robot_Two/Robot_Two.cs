using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Two : Enemy
{
    [SerializeField] GameObject sawBladePrefab;
    [SerializeField] GameObject shockwavePrefab;
    int[] angles = new int[2] { 45, -45 };
    int[] directions = new int[2] { -1, 1 };
    int randomAngleValue;
    int randomDirValue;

    protected override void Start() {
        base.Start();
        InvokeRepeating("SpawnSawBlade", 5f, 8f);
        InvokeRepeating("Shockwaves", 10f, 10f);
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if(health == 40) {
            speed = 2f;
        } 
        if(health == 20) {
            speed = 2.5f;
        }
    }

    protected override void Dying() {
        base.Dying();
        if (Health <= 0) {
            GameObject[] ball = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in ball) {
                GameObject.Destroy(obj);
            }
        }
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

    void Shockwaves() {
        GameObject spawnedPrefab = Instantiate(shockwavePrefab);
        spawnedPrefab.transform.position = transform.position;
    }
}
