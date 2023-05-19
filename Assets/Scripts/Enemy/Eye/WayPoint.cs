using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private void Start() {
        Destroy(this.gameObject, 2.5f);
    }
}
