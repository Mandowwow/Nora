using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private static float nextFire = 0f;
    private static float fireRate = 0.25f;
    public List<GameObject> enemies = new List<GameObject>();
    void Update()
    {
        //if(Time.time > nextFire) {
        //    foreach (GameObject enemy in enemies) {
        //        enemy.
        //    }
        //}
        Destroy(this.gameObject, 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            enemies.Add(collision.gameObject);
            Debug.Log(enemies.Count);
            //collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy") && Time.time > nextFire) {          
            foreach (GameObject enemy in enemies) {
                enemy.GetComponent<Enemy>().TakeDamage(1);
                Debug.Log(enemy.name);
            }
            nextFire = Time.time + fireRate;
        }
    }

}
