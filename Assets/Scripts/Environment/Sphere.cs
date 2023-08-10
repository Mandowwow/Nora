using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius = 2f;
    [SerializeField] float angularSpeed = 2f;
    [SerializeField] float angle = 0f;
    Vector3 moveDirection;
    float posX, posY;
    private void Update() {
        Rotate();
    }
    void Rotate() {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
            angle = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Debug.Log("Touch blue ball");
            moveDirection = collision.GetComponentInParent<Rigidbody2D>().transform.position - transform.position;
            collision.GetComponentInParent<Rigidbody2D>().AddForce(-moveDirection.normalized * -0.065f);
        }
    }
}
