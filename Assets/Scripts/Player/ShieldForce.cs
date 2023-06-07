using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldForce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Wall")) {           
            Debug.Log("Not wall");
            StartCoroutine(Change()); 
        }
    }

    IEnumerator Change() {
        Collider2D col = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        col.enabled = false;
        CharacterStats.Shield = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        Debug.Log("Shield is off now");
        col.enabled = true;
        gameObject.SetActive(false);

    }
}
