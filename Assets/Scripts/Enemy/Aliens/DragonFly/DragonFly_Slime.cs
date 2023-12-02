using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly_Slime : MonoBehaviour
{
    PlayerStats ps;
    private void Start() {
        ps = FindObjectOfType<PlayerStats>();
        StartCoroutine(DestroyThis());
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponentInParent<PlayerMovement>()) {
            //CharacterStats.PlayerSpeed = 0.025f;
            ps.CurrentMoveSpeed = 0.025f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponentInParent<PlayerMovement>()) {
            //CharacterStats.PlayerSpeed = 0.1f;
            ps.CurrentMoveSpeed = 0.1f;
        }
    }

    IEnumerator DestroyThis() {
        yield return new WaitForSeconds(10f);
        //CharacterStats.PlayerSpeed = 0.1f;
        ps.CurrentMoveSpeed = 0.1f;
        Destroy(this.gameObject);
    }
}
