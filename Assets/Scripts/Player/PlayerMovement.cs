using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement Variables
    [SerializeField] private Rigidbody2D rb = null;
    private Vector2 movement;

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

    }

    private void FixedUpdate() {
        if (KBCounter <= 0) {
            //rb.MovePosition(rb.position + movement.normalized * runSpeed * Time.fixedDeltaTime);
            rb.AddForce(movement.normalized * CharacterStats.PlayerSpeed * Time.fixedDeltaTime);
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
}
