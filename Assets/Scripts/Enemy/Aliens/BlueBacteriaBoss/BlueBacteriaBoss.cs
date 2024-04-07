using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBacteriaBoss : Enemy
{
    [SerializeField] private bool movingRight = true;
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private float interval = 1f;
    [SerializeField] private float interval2 = 10f;
    [SerializeField] private int numOfInstances = 16;
    private float timer = 0f;
    public Phase currentPhase = Phase.Phase1;

    public enum Phase {
        Phase1,
        Phase2
    }

    protected override void Start() {
        base.Start();
        StartCoroutine(TriggerOrbsSpawn());
    }
    protected override void ChasePlayer() {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
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
                float xCoordinate = spawnPosition.x + i;
                Vector3 instancePosition = new Vector3(xCoordinate, spawnPosition.y, spawnPosition.z);
                GameObject newPrefabInstance = Instantiate(prefab, instancePosition, Quaternion.identity);
                yield return new WaitForSeconds(interval);
            }
            currentPhase = Phase.Phase2;
        } else {
            Vector3 spawnPosition = new Vector3(-7.5f, -3.3f, 0f);

            for (float i = 0; i < numOfInstances; i += 1f) {
                float xCoordinate = spawnPosition.x + i;
                Vector3 instancePosition = new Vector3(xCoordinate, spawnPosition.y, spawnPosition.z);
                GameObject newPrefabInstance = Instantiate(prefab, instancePosition, Quaternion.identity);
                yield return new WaitForSeconds(interval);
            }
            currentPhase = Phase.Phase1;
        }
    }
}
