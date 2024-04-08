using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBacteriaBoss : Enemy
{
    [SerializeField] private bool movingRight = true;
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private GameObject prefabBlowUp = null;
    [SerializeField] private float interval = 1f;
    [SerializeField] private float interval2 = 10f;
    [SerializeField] private int numOfInstances = 16;
    private float timer = 0f;
    public Phase currentPhase = Phase.Phase1;

    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    public enum Phase {
        Phase1,
        Phase2,
        Phase3
    }

    protected override void Start() {
        base.Start();
        StartCoroutine(TriggerOrbsSpawn());
    }

    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if (health <= 30) {
            currentPhase = Phase.Phase3;
            StopCoroutine(TriggerOrbsSpawn());
        }
    }
    protected override void ChasePlayer() {      
        if(currentPhase == Phase.Phase3) {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) {
                speed = 2.5f;
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.down);
                BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.down);
                BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, 0) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, 0) * Vector3.down);
                BlowUp(Quaternion.Euler(0, 0, 90) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, 90) * Vector3.down);
            }

            LookAtWayPoint();

        } else {
            transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
        }
    }
    protected override void Attack() {
        timer += Time.deltaTime;
        if(timer > interval2) {
            StartCoroutine(TriggerOrbsSpawn());
            timer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            if (movingRight == false) {
                transform.eulerAngles = new Vector3(0, 0, 90);
                movingRight = true;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, -90);
                movingRight = false;
            }
        }

        if (collision.gameObject.CompareTag("Controller")) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            Vector3 moveDirection = collision.gameObject.GetComponent<Rigidbody2D>().transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-moveDirection.normalized * -0.075f);
        }
    }

    IEnumerator TriggerOrbsSpawn() {
        if(currentPhase == Phase.Phase1) {
            Vector3 spawnPosition = new Vector3(-7.5f, 3.3f, 0f);

            for (float i = 0; i < numOfInstances; i += 1f) {
                if(Health > 30) {
                    float xCoordinate = spawnPosition.x + i;
                    Vector3 instancePosition = new Vector3(xCoordinate, spawnPosition.y, spawnPosition.z);
                    GameObject newPrefabInstance = Instantiate(prefab, instancePosition, Quaternion.identity);
                    yield return new WaitForSeconds(interval);
                }
            }
            if(Health > 30) {
                currentPhase = Phase.Phase2;
            }
        } 
        
        else if (currentPhase == Phase.Phase2) {
            Vector3 spawnPosition = new Vector3(-7.5f, -3.3f, 0f);

            for (float i = 0; i < numOfInstances; i += 1f) {
                if(Health > 30) {
                    float xCoordinate = spawnPosition.x + i;
                    Vector3 instancePosition = new Vector3(xCoordinate, spawnPosition.y, spawnPosition.z);
                    GameObject newPrefabInstance = Instantiate(prefab, instancePosition, Quaternion.identity);
                    yield return new WaitForSeconds(interval);
                }
            }
            if (Health > 30) {
                currentPhase = Phase.Phase1;
            }
        }
    }

    private void BlowUp(Vector3 dir) {
        GameObject spawnedBullet = Instantiate(prefabBlowUp);
        spawnedBullet.transform.position = transform.position;
        spawnedBullet.GetComponent<CrystalBlue_Ball>().DirectionCalc(dir);
    }

    void LookAtWayPoint() {
        Vector3 wayPointPos = waypoints[currentWaypointIndex].position;

        Vector2 direction = new Vector2(
            wayPointPos.x - transform.position.x,
            wayPointPos.y - transform.position.y);
        transform.up = direction.normalized;
    }
}
