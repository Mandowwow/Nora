using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update() {
        transform.Rotate(0, 0, 360f * Time.deltaTime);
    }

    private IEnumerator Destroy() {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Health>()) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }

}
