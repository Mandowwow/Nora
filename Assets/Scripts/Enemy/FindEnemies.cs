using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemies : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    private static List<GameObject> enemies = new List<GameObject>();

    public static List<GameObject> Enemies => enemies;

    public GameObject Portal => portal;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("FindObjects", 0.1f);
    }

    public void FindObjects() {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            enemies.Add(enemy);
            Debug.Log(enemy);
        }
    }
}
