using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    float nextMovement = 0f;
    float movementRate = 4f;
    [SerializeField] bool moveRight = true;

    private void Start() {
        InvokeRepeating("ChangeDirection", 9.5f, 9.5f);
        Invoke("Destroy", 28f);
    }
    void Update()
    {
        if(moveRight == true) {
            transform.Translate(Time.deltaTime * 1.5f, 0, 0);
        } else {
            transform.Translate(-Time.deltaTime * 1.5f, 0, 0);
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

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
        }
    }
}
