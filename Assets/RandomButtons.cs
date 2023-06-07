using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButtons : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject parentObject;

    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        GameObject newAbility = Instantiate(objects[rand], transform.position, Quaternion.identity) as GameObject;
        newAbility.transform.SetParent(parentObject.transform);

    }
}
