using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBat : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    private void Update() {
        //FindClosestEnemy();
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        FindClosestEnemy();
    }

    void FindClosestEnemy() {
        float distanceToClosestEnemy = Mathf.Infinity;
        Enemy closestEnemy = null;
        Enemy[] allEnemies = GameObject.FindObjectsOfType<Enemy>();

        foreach(Enemy currentEnemy in allEnemies) {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestEnemy) {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        Vector3 targetPos = closestEnemy.transform.position;
        Vector2 direction = new Vector2(
            targetPos.x - transform.position.x,
            targetPos.y - transform.position.y);
        //transform.up = direction;
        rb.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Enemy>()) {
            collision.GetComponent<Enemy>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
