using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_One_DroneBulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _bulletTarget;
    public GameObject BulletTarget
    {
        set => _bulletTarget = value;
    }
    private GameObject target;
    private Rigidbody2D rb;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        target = _bulletTarget.transform.Find("center/circumference").gameObject;
        Shoot();
    }

    private void Shoot() {
        Vector3 targetPos = target.transform.position;
        Vector2 direction = new Vector2(
            targetPos.x - transform.position.x,
            targetPos.y - transform.position.y);
        transform.up = direction;
        rb.velocity = direction.normalized * 6f;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Wall")) {
            Destroy(this.gameObject);
        }
    }
}
