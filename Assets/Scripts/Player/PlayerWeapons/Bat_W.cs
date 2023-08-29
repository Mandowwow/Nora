using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_W : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            CharacterStats.CurrentWeapon = CharacterStats.Weapon.Bat;
            Destroy(this.gameObject);
            Debug.Log("weapon");
        }
    }
}
