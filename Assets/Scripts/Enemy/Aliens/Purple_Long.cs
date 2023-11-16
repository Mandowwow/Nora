using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple_Long : Enemy
{
    [SerializeField] private GameObject spit = null;
    [SerializeField] private GameObject barrel = null;
    private Animator anim;

    protected override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
    }
    protected override void ChasePlayer() {
        if(player != null) {
            if (Vector2.Distance(transform.position, player.position) >= 0f) {
                anim.Play("Spit");
            }
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
    public void Spit() {
        if (Vector2.Distance(transform.position, player.position) < 13f) {
            rb.velocity = new Vector2(0f,0f);
            Instantiate(spit, barrel.transform.position, Quaternion.identity);
        }
    }
}
