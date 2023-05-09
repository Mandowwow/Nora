using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : Enemy
{
    [SerializeField] private bool movingRight = true;
    protected override void ChasePlayer() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);                   
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            if (movingRight == false) {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = true;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = false;
            }
        }
        if (collision.collider.gameObject.tag == "Player") {
            Debug.Log("Detected");
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x) {
                playerMovement.knockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x) {
                playerMovement.knockFromRight = false;
            }

        }

    }


}

