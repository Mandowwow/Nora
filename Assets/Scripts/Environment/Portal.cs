using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //refrences
    PlayerMovement pm;

    private void Start() {
        pm = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            collision.transform.parent.position = new Vector3(0f, -3.5f, 0f);
            pm.isSlowed = false;
        }
    }

    public void Collider() {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
