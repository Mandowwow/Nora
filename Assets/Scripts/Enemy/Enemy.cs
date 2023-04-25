using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected private float speed;
    [SerializeField] protected private int health;
    [SerializeField] protected private SpriteRenderer sprite;
    [SerializeField] protected private Rigidbody2D rb;
    private static int playerPoints;
    protected private Transform player;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            Debug.Log(playerPoints);
            FindEnemies.Enemies.Remove(this.gameObject);
            if (FindEnemies.Enemies.Count <= 0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }

    IEnumerator Change() {
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.black;
    }
}
