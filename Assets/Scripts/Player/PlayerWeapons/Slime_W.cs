using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_W : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            CharacterStats.CurrentWeapon = CharacterStats.Weapon.Slime;
            Destroy(this.gameObject);
            Debug.Log("weapon");
        }
    }
}
