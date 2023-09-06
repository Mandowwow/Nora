using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private void Start() {
        Destroy(this.gameObject, 1.5f);
    }
    void Update()
    {
        transform.localScale += new Vector3(1f, 1f) * Time.deltaTime * 2;
    }
}
