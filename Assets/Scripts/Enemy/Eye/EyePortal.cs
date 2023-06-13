using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyePortal : MonoBehaviour
{
    [SerializeField] private GameObject enemy = null;
    public void Spawn() {
        Instantiate(enemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
