using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishPurple_Explosion : MonoBehaviour
{
    Animator anim;
    public enum Phase {
        Phase1,
        Phase2
    }

    Phase currentPhase = Phase.Phase1;

    private void Start() {
        anim = GetComponent<Animator>();
        StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2f);
        currentPhase = Phase.Phase2;
        anim.Play("Explode");
        yield return new WaitForSeconds(9f);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player") && currentPhase == Phase.Phase2) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
        }
    }
}
