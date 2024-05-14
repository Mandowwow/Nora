using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Two : Enemy
{
    public enum Phase {
        one,
        two
    }
    public Phase currentPhase = Phase.one;
    [SerializeField] GameObject sawBladePrefab;
    [SerializeField] GameObject shockwavePrefab;
    float sawBladeTimer = 8f;
    float shockWavetimer = 10f;
    int[] angles = new int[2] { 45, -45 };
    int[] directions = new int[2] { -1, 1 };
    int randomAngleValue;
    int randomDirValue;

    protected override void Start() {
        base.Start();
        InvokeRepeating("SpawnSawBlade", 5f, sawBladeTimer);
        InvokeRepeating("Shockwaves", 10f, shockWavetimer);
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if(health == 40) {
            CancelInvoke("Shockwaves");
            CancelInvoke("SpawnSawBlade");
            currentPhase = Phase.two;
            shockWavetimer = 1f;
            sawBladeTimer = 6f;
            InvokeRepeating("Shockwaves", 5f, shockWavetimer);
            InvokeRepeating("SpawnSawBlade", 5f, sawBladeTimer);
        }
    }

    protected override void ChasePlayer() {
        switch (currentPhase) {
            case Phase.one:
                base.ChasePlayer();
                break;
            case Phase.two:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), speed * Time.fixedDeltaTime);
                break;
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
