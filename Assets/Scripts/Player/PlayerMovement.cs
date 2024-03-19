using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    private Vector2 movement;
    public bool isSlowed = false;

    //Knockback Variables
    public float KBCounter;
    public float KBTotalTime;
    public float KBForce;

    public bool knockFromRight;

    //Refrences
    [SerializeField] private Rigidbody2D rb = null;
    PlayerStats ps;

    private void Start() {
        ps = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate() {
        if (KBCounter <= 0 && !isSlowed) {
            //rb.MovePosition(rb.position + movement.normalized * runSpeed * Time.fixedDeltaTime);
            rb.AddForce(movement.normalized * ps.CurrentMoveSpeed * Time.fixedDeltaTime);
            //rb.velocity = movement.normalized * runSpeed * Time.fixedDeltaTime;
        } 
        else if (KBCounter <= 0 && isSlowed) {
            rb.AddForce(movement.normalized * 0.025f * Time.fixedDeltaTime);
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
}
