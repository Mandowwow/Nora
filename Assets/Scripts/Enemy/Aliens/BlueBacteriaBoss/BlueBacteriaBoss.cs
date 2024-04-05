using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBacteriaBoss : Enemy
{
    [SerializeField] private bool movingRight = true;
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private float interval = 1f;
    [SerializeField] private int numOfInstances = 16;
    private float timer = 0f;

    protected override void Start() {
        base.Start();
        StartCoroutine(TriggerOrbsSpawn());
    }
    protected override void ChasePlayer() {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
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
        Vector3 spawnPosition = new Vector3(-8f, 3.3f, 0f);

        for (float i = 0; i < numOfInstances; i += 0.5f) {
            float xCoordinate = spawnPosition.x + i;
            Vector3 instancePosition = new Vector3(xCoordinate, spawnPosition.y, spawnPosition.z);
            GameObject newPrefabInstance = Instantiate(prefab, instancePosition, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
}
