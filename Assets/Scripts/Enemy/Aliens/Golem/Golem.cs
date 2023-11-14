using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    [SerializeField] private GameObject boulder;
    [SerializeField] GameObject barrel = null;
    [SerializeField] GameObject barrel2 = null;
    [SerializeField] GameObject barrel3 = null;
    [SerializeField] GameObject barrel4 = null;
    [SerializeField] GameObject barrel5 = null;
    [SerializeField] GameObject barrel6 = null;
    [SerializeField] GameObject barrel7 = null;
    [SerializeField] GameObject barrel8 = null;

    private Animator anim;

    public enum ShootDir{
        Diagonal,
        Cross,
        Both
    }

    ShootDir shootDir = ShootDir.Diagonal;

    protected override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
        InvokeRepeating("Shoot", 5f, 5f);  
    }
    protected override void ChasePlayer() {
        base.ChasePlayer();
        TurnDirection();
    }

    private void TurnDirection() {
        if (player != null) {
            if (transform.position.x > player.transform.position.x) {
                sprite.flipX = true;
            }
            else {
                sprite.flipX = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
            Vector3 moveDirection = collision.gameObject.GetComponent<Rigidbody2D>().transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-moveDirection.normalized * -0.035f);
        }
    }

    public void Chase() {
        speed = 1.5f;
        anim.Play("Idle");
    }

    public void Shoot() {
        speed = 0;
        anim.Play("Attack");
    }

    private void BlowUp() {
        if (shootDir == ShootDir.Diagonal) {
            Instantiate(boulder, barrel.transform.position,  barrel.transform.rotation);
            Instantiate(boulder, barrel2.transform.position, barrel2.transform.rotation);
            Instantiate(boulder, barrel3.transform.position, barrel3.transform.rotation);
            Instantiate(boulder, barrel4.transform.position, barrel4.transform.rotation);
            shootDir = ShootDir.Cross;
        } else if (shootDir == ShootDir.Cross) {
            Instantiate(boulder, barrel5.transform.position, barrel5.transform.rotation);
            Instantiate(boulder, barrel6.transform.position, barrel6.transform.rotation);
            Instantiate(boulder, barrel7.transform.position, barrel7.transform.rotation);
            Instantiate(boulder, barrel8.transform.position, barrel8.transform.rotation);
            shootDir = ShootDir.Diagonal;
        } else if (shootDir == ShootDir.Both) {
            Instantiate(boulder, barrel.transform.position, barrel.transform.rotation);
            Instantiate(boulder, barrel2.transform.position, barrel2.transform.rotation);
            Instantiate(boulder, barrel3.transform.position, barrel3.transform.rotation);
            Instantiate(boulder, barrel4.transform.position, barrel4.transform.rotation);
            Instantiate(boulder, barrel5.transform.position, barrel5.transform.rotation);
            Instantiate(boulder, barrel6.transform.position, barrel6.transform.rotation);
            Instantiate(boulder, barrel7.transform.position, barrel7.transform.rotation);
            Instantiate(boulder, barrel8.transform.position, barrel8.transform.rotation);
            shootDir = ShootDir.Diagonal;
        }
    }
}
   