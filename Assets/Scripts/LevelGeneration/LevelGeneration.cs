using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private static int playerPoints = 0;
    private static bool firstLevel = true;

    public List<GameObject> levels = new List<GameObject>();
    public static List<GameObject> newLevels = null;

    public static int PlayerPoints
    {
        get => playerPoints;
        set => playerPoints = value;
    }
    public static bool FirstLevel
    {
        get => firstLevel;
        set => firstLevel = value;
    }

    private void Start() {
        playerPoints += 1;

        if (firstLevel == true) {
            newLevels = new List<GameObject>(levels);
            firstLevel = false;
        }
             
        switch (playerPoints) {
            case 1:
            case 2:
            case 3:
                int rand = Random.Range(0, 4);
                while (newLevels[rand] == null) {
                    rand = Random.Range(0, 4);
                }
                Instantiate(newLevels[rand], transform.position, Quaternion.identity);
                newLevels[rand] = null;
                break;
            case 4:
                rand = Random.Range(4, 7);
                while (newLevels[rand] == null) {
                    rand = Random.Range(4, 7);
                }
                Instantiate(newLevels[rand], transform.position, Quaternion.identity);
                newLevels[rand] = null;
                break;
            case 5:
            case 6:
            case 7:
                rand = Random.Range(8, 11);
                while (newLevels[rand] == null) {
                    rand = Random.Range(8, 11);
                }
                Instantiate(newLevels[rand], transform.position, Quaternion.identity);
                newLevels[rand] = null;
                break;
            case 8:
                rand = Random.Range(11, 13);
                while (newLevels[rand] == null) {
                    rand = Random.Range(11, 13);
                }
                Instantiate(newLevels[rand], transform.position, Quaternion.identity);
                newLevels[rand] = null;
                break;
            case 9:
            case 10:
            case 11:
                rand = Random.Range(13,17);
                while (newLevels[rand] == null) {
                    rand = Random.Range(13,17);
                }
                Instantiate(newLevels[rand], transform.position, Quaternion.identity);
                newLevels[rand] = null;
                break;
            case 12:
                Instantiate(newLevels[17], transform.position, Quaternion.identity);
                newLevels[17] = null;
                break;
            case 13:
            case 14:
            case 15:
                rand = Random.Range(18, 21);
                while (newLevels[rand] == null) {
                    rand = Random.Range(18, 22);
                }
                Instantiate(newLevels[rand], transform.position, Quaternion.identity);
                newLevels[rand] = null;
                break;

        }
    }
}
