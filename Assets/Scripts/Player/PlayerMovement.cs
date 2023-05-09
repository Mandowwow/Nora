using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float runSpeed;
    private Vector2 movement;

    //Shooting Variables
    private float nextFire = 0f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject bulletPrefab;
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

        if(Input.GetKey("right") && Time.time > nextFire) {
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
    }

    private void FixedUpdate() {
        if (KBCounter <= 0) {
            rb.MovePosition(rb.position + movement.normalized * runSpeed * Time.fixedDeltaTime);
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
}
