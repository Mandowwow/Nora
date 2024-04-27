using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    public Animator anim;
    private float randTime;
    [SerializeField] private bool canMove = true;
    public float speed;
    private GameObject target;
    private Rigidbody2D rb;
    private Vector2 randPos;
    public bool chase = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        randTime = Random.Range(1f, 3f);
        randPos = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.15f, 3.15f));
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer() {
        if(chase == true) {
            Vector3 targetPos = target.transform.position;
            Vector2 direction = new Vector2(
                targetPos.x - transform.position.x,
                targetPos.y - transform.position.y);
            //rb.velocity = direction.normalized * speed;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        } else {
            if (Vector2.Distance(transform.position, randPos) > 0.1) {
                rb.velocity = new Vector2(0f, 0f);
                transform.position = Vector2.MoveTowards(transform.position, randPos, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, randPos) <= 0.1 && canMove == true) {
                StartCoroutine(Wait());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(1);

        }
    }

    private IEnumerator Wait() {
        canMove = false;
        yield return new WaitForSeconds(randTime);
        randPos = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.15f, 3.15f));
        randTime = Random.Range(0.25f, 0.5f);
        canMove = true;
    }
}
