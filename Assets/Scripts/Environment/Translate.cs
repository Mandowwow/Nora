using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    float nextMovement = 0f;
    float movementRate = 4f;
    [SerializeField] bool moveRight = true;

    private void Start() {
        InvokeRepeating("ChangeDirection", 14f, 14f);
        Invoke("Destroy", 28f);
    }
    void Update()
    {
        if(moveRight == true) {
            transform.Translate(Time.deltaTime, 0, 0);
        } else {
            transform.Translate(-Time.deltaTime, 0, 0);
        }
    }

    private void ChangeDirection()
    {
        if(moveRight == true) {
            moveRight = false;
        } else {
            moveRight = true;
        }
    }

    private void Destroy() {
        Destroy(this.gameObject);
    }
}
