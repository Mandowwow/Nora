using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{
    [SerializeField] private Transform[] ghostPlayers;
    private Transform player;
    private float speed = 1f;
    private int rand;

    private void Start() {
        rand = Random.Range(0, 3);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update() {
        ChasePlayer();
    }

    private void ChasePlayer() {
        
        if(Vector2.Distance(transform.position, ghostPlayers[rand].position) < 1) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            Debug.Log("Chasing actual player now");
        } else {
            transform.position = Vector2.MoveTowards(transform.position, ghostPlayers[rand].position, speed * Time.deltaTime);
            Debug.Log("Chasing ghosts");
        }

    }

    //------------------KNOCKBACK----------------------//
    //private void OnCollisionStay2D(Collision2D collision) {
    //    if (collision.collider.gameObject.CompareTag("Player")) {
    //        Vector2 a = player.position;
    //        Vector2 b = transform.position;

    //        Vector2 direction = (a - b).normalized;
    //        Vector2 knockback = direction * 5f;
    //        rb = collision.gameObject.GetComponent<Rigidbody2D>();
    //        //rb.AddForce(knockback);
    //        rb.velocity = new Vector2(knockback.x, knockback.y);
    //    }
    //}
}
