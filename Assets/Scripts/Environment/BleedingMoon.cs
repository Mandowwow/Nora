using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleedingMoon : MonoBehaviour
{

    private void Start() {
        Invoke("HealthBuff", 0.2f);
    }

    private void HealthBuff() {
        foreach (GameObject enemy in FindEnemies.Enemies) {
            enemy.GetComponent<Enemy>().Health += 1;
        }
    }
}
