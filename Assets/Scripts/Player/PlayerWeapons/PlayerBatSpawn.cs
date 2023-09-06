using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBatSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bat = null;
    public void Spawn() {
        Instantiate(bat, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
