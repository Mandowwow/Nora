using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private static float nextFire = 0f;
    private static float fireRate = 0.25f;
    private Collider2D col;
    public List<GameObject> enemies = new List<GameObject>();

    private void Start() {
        Destroy(this.gameObject, 0.5f);
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(Damage());
        collision.GetComponent<Enemy>().TakeDamage(1);
    }

    private IEnumerator Damage() {
        col.enabled = false;
        yield return new WaitForSeconds(0.25f);
        col.enabled = true;
    }
    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if (collision.GetComponent<Enemy>()) {
    //        if (!enemies.Contains(collision.gameObject)) {
    //            enemies.Add(collision.gameObject);
    //        }
    //        Debug.Log(enemies.Count);
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision) {
    //    if (collision.gameObject.CompareTag("Enemy") && Time.time > nextFire) {          
    //        foreach (GameObject enemy in enemies) {
    //            enemy.GetComponent<Enemy>().TakeDamage(1);
    //            if(enemy.GetComponent<Enemy>().Health <= 0) {
    //                enemies.Remove(enemy);
    //                Debug.Log("Removed " + enemy.name);
    //            }
    //            nextFire = Time.time + fireRate;
    //        }
    //    }
    //}
}
