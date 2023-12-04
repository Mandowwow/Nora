using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //refrences
    public PlayerScriptableObject playerData;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //playerData.MoveSpeed = 0.1f;
        }
    }

    public void Collider() {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
