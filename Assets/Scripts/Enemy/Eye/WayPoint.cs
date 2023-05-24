using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private float time;
    private void Start() {
        Destroy(this.gameObject, time);
    }
}
