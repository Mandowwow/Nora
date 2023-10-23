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
    [SerializeField] protected private float fireRate = 0.6f;
    private LevelUpMenu levelUpMenuUi;
    protected private float nextFire = 0f;
    protected private PlayerMovement playerMovement;
    protected private Transform player;
    protected private Collider2D col;
    //protected private static int playerPoints;
    protected private FindEnemies findEnemies;

    public int Health
    {
        get => health;
        set => health = value;
    }
    //public static int PlayerPoints
    //{
    //    get => playerPoints;
    //    set => playerPoints = value;
    //}

    protected virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement = GameObject.FindGameObjectWithTag("Controller").GetComponent<PlayerMovement>();
        findEnemies = GameObject.FindGameObjectWithTag("Manager").GetComponent<FindEnemies>();
        levelUpMenuUi = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelUpMenu>();
        sprite = GetComponent<SpriteRenderer>();
        FindEnemies.Enemies.Add(this.gameObject);
        //sprite.color = Color.black;
    }

    private void Update() {
        //ChasePlayer();
        Attack();
    }

    private void FixedUpdate() {
        ChasePlayer();
    }

    public virtual void TakeDamage(int damage) {
        Health -= damage;
        ChangeColor();
        Dying();
    }

    protected virtual void ChasePlayer() {
        if (Vector2.Distance(transform.position, player.position) < 12 && Vector2.Distance(transform.position, player.position) > 0.35f) {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
        }
    }

    protected virtual void Attack() {
    }

    private void ChangeColor() {
        sprite.color = new Color(110, 0, 0);
        StartCoroutine(Change());
    }

    protected virtual void Dying() {
        if (health <= 0) {
            Destroy(this.gameObject);
            RandomDrop();
            FindEnemies.Enemies.Remove(this.gameObject);
            if (FindEnemies.Enemies.Count <= 0) {
                Instantiate(findEnemies.Portal, new Vector3(0,0,0), Quaternion.identity);
                //LevelUp();
            }

        }
    }

    protected virtual void LevelUp()
    {
        levelUpMenuUi.OpenMenu();
    }

    protected void RandomDrop() {
        int rand = Random.Range(1, 26);
        if(rand > 24) {
            //1 in 25 chance 
            Instantiate(heart, transform.position, Quaternion.identity);
        }
    }

    protected virtual IEnumerator Change() {
        yield return new WaitForSeconds(0.1f);
        //sprite.color = Color.black;
        sprite.color = Color.white;
    }
    

}
