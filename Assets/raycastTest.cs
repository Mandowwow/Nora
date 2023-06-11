using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastTest : MonoBehaviour
{
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        if (hit) {
            Debug.Log(hit.collider);

        }
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
    }
}
