using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Weapon {
    Gun,
    Lazer
}
public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private float runSpeed = 0;
    private Vector2 movement;

    //Shooting Variables
    private Weapon currentWeapon = Weapon.Lazer;
    private float nextFire = 0f;
    bool canShoot = true;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private GameObject charge;
    [SerializeField] private Transform shootU;
    [SerializeField] private Transform shootD;
    [SerializeField] private Transform shootL;
    [SerializeField] private Transform shootR;

    //Knockback Variables
    public float KBCounter;
    public float KBTotalTime;
    public float KBForce;

    public bool knockFromRight;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        switch (currentWeapon) {
            case Weapon.Gun:
                if (Input.GetKey("right") && Time.time > nextFire) {
                    Shoot(shootR);
                }
                else if (Input.GetKey("left") && Time.time > nextFire) {
                    Shoot(shootL);
                }
                else if (Input.GetKey("down") && Time.time > nextFire) {
                    Shoot(shootD);
                }
                else if (Input.GetKey("up") && Time.time > nextFire) {
                    Shoot(shootU);
                }
                break;

            case Weapon.Lazer:
                if (Input.GetKey("right") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootR));
                }
                else if (Input.GetKey("left") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootL));
                }
                else if (Input.GetKey("down") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootD));
                }
                else if (Input.GetKey("up") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootU));
                }
                break;
        } 
    }

    private void FixedUpdate() {
        if (KBCounter <= 0) {
            //rb.MovePosition(rb.position + movement.normalized * runSpeed * Time.fixedDeltaTime);
            rb.AddForce(movement.normalized * runSpeed * Time.fixedDeltaTime);
            //rb.velocity = movement.normalized * runSpeed * Time.fixedDeltaTime;
        }
        else {
            if (knockFromRight == true) {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (knockFromRight == false) {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
    }

    private void Shoot(Transform pos) {
        Instantiate(bulletPrefab, pos.position, pos.rotation);
        nextFire = Time.time + fireRate;
    }

    private IEnumerator LazerShoot(Transform pos) {
        Instantiate(charge, pos.position, pos.rotation, pos);
        canShoot = false;
        yield return new WaitForSeconds(0.45f);
        canShoot = true;
        Instantiate(lazerPrefab, pos.position, pos.rotation, pos);
        nextFire = Time.time + fireRate;
    }
}
