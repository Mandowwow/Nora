using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void Awake() {
        playerMovement = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Controller") {
            Debug.Log("Detected");
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x) {
                playerMovement.knockFromRight = true;
            }
            if(collision.transform.position.x > transform.position.x) {
                playerMovement.knockFromRight = false;
            }
        }
    }
}
