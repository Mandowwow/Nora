using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePortal : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public void Spawn() {
        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
