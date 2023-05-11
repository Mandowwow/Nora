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
}
