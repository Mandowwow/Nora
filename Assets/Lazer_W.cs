using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_W : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            CharacterStats.CurrentWeapon = CharacterStats.Weapon.Lazer;
            Debug.Log("weapon");
        }
    }
}
