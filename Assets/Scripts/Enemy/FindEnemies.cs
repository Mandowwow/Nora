using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemies : MonoBehaviour
{
    private static List<GameObject> enemies = new List<GameObject>();

    public static List<GameObject> Enemies
    {
        get
        {
            return enemies;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FindObjects", 0.1f);
    }

    void FindObjects() {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            enemies.Add(enemy);
        }
    }
}
