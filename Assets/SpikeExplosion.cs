using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeExplosion : MonoBehaviour
{
    private Vector3 scaleChange;

    private void Awake() {
        scaleChange = new Vector3(-2f, -2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= scaleChange * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
