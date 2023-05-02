using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected private float speed;
    [SerializeField] protected private int health;
    [SerializeField] protected private SpriteRenderer sprite;
    [SerializeField] protected private Rigidbody2D rb;
    [SerializeField] private GameObject heart;
    protected private PlayerMovement playerMovement;
    protected private Transform player;
    private static int playerPoints;
    private FindEnemies findEnemies; 

    protected virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerMovement>();
        findEnemies = GameObject.FindGameObjectWithTag("Manager").GetComponent<FindEnemies>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = Color.black;
    }

    private void Update() {
        ChasePlayer();
    }

    public void TakeDamage(int damage) {
        health -= damage;
        ChangeColor();
        Dying();
    }

    protected virtual void ChasePlayer() {
        if (Vector2.Distance(transform.position, player.position) < 10 && Vector2.Distance(transform.position, player.position) > 0.625f) {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void ChangeColor() {
        sprite.color = new Color(110, 0, 0);
        StartCoroutine(Change());
    }

    private void Dying() {
        if (health <= 0) {
            Destroy(this.gameObject);
            playerPoints += 1;
            RandomDrop();
            FindEnemies.Enemies.Remove(this.gameObject);
            if (FindEnemies.Enemies.Count <= 0) {
                Instantiate(findEnemies.Portal, new Vector3(0,0,0), Quaternion.identity);
            }

        }
    }

    private void RandomDrop() {
        int rand = Random.Range(1, 26);
        if(rand > 24) {
            //1 in 25 chance 
            Instantiate(heart, transform.position, Quaternion.identity);
        }
    }

    IEnumerator Change() {
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.black;
    }

}
