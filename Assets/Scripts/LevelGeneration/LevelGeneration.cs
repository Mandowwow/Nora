using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects = null;
    private static int playerPoints = 0;

    public static int PlayerPoints
    {
        get => playerPoints;
        set => playerPoints = value;
    }

    private void Start() {
        playerPoints += 1;
        if(playerPoints >= 1 && playerPoints < 4) {
            int rand = Random.Range(0, 4);
            Instantiate(objects[rand], transform.position, Quaternion.identity);
            Debug.Log(playerPoints);

        } else if (playerPoints >= 4 && playerPoints < 5) {
            int rand = Random.Range(4, 7);
            Instantiate(objects[rand], transform.position, Quaternion.identity);
        } else if (playerPoints >= 5) {
            int rand = Random.Range(7, 10);
            Instantiate(objects[rand], transform.position, Quaternion.identity);
        }

    }
}
