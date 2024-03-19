using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFly_Slime : MonoBehaviour
{
    PlayerMovement pm;
    float slowMovement = 0.025f;
    private void Start() {
        pm = FindObjectOfType<PlayerMovement>();
        StartCoroutine(DestroyThis());
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.GetComponentInParent<PlayerMovement>()) {
            pm.isSlowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponentInParent<PlayerMovement>()) {
            pm.isSlowed = false;
        }
    }

    IEnumerator DestroyThis() {
        yield return new WaitForSeconds(10f);
        pm.isSlowed = false;
        Destroy(this.gameObject);
    }
}
