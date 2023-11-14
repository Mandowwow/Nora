﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            CharacterStats.PlayerSpeed = 0.1f;
        }
    }

    public void Collider() {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
