using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly_Slime : MonoBehaviour
{
    private void Start() {
        StartCoroutine(DestroyThis());
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponentInParent<PlayerMovement>()) {
            CharacterStats.PlayerSpeed = 0.025f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponentInParent<PlayerMovement>()) {
            CharacterStats.PlayerSpeed = 0.1f;
        }
    }

    IEnumerator DestroyThis() {
        yield return new WaitForSeconds(10f);
        CharacterStats.PlayerSpeed = 0.1f;
        Destroy(this.gameObject);
    }
}
