using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCell : Enemy
{
    public enum Phase {
        one,
        two,
        three
    }
    [SerializeField] private GameObject cell = null;
    [SerializeField] private GameObject spike = null;
    [SerializeField] private GameObject crystal = null;
    [SerializeField] public GameObject explosion;
    [SerializeField] private GameObject[] shootPos = null;
    private int rand = 0;
    private Vector3 moveDirection;
    private bool leftSide = true;
    private Vector2 center = new Vector2(0,0);
    private Vector2 randPos = new Vector2(0, 0);
    public Phase currentPhase = Phase.one;

    protected override void Start() {
        base.Start();
    }
    protected override void ChasePlayer() {
        switch (currentPhase) {
            case Phase.one:
                base.ChasePlayer();
                PlayerDirection();
                break;
            case Phase.two:               
                transform.Rotate(new Vector3(0f, 0f, 148f) * Time.deltaTime);
                break;
            case Phase.three:
                Vector3 directionPos = center;
                direction = new Vector2(
                   directionPos.x - transform.position.x,
                   directionPos.y - transform.position.y);
                transform.up = direction;
                transform.position = Vector2.MoveTowards(transform.position, center, speed * Time.fixedDeltaTime);
                break;
            default:
                break;
        }
    }
    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if(Health == 55) {
            SpawnCrystal();
            InvokeRepeating("SpawnSpikes", 5f, 0.01f);
            StartCoroutine(StopSpikes());
        } else if (Health == 45) {
            SpawnCrystal();
            InvokeRepeating("SpawnSpikes", 5f, 0.01f);
            StartCoroutine(StopSpikes());
        } else if (Health == 35) {
            SpawnCrystal();
            InvokeRepeating("SpawnSpikes", 5f, 0.01f);
            StartCoroutine(StopSpikes());
        } else if (Health == 25) {
            currentPhase = Phase.three;
            InvokeRepeating("SpawnCells", 2f, 2.5f);
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.gameObject.CompareTag("Player") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
            moveDirection = collision.gameObject.GetComponent<Rigidbody2D>().transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-moveDirection.normalized * -0.065f);
        }
    }
    private IEnumerator StopSpikes() {
        yield return new WaitForSeconds(7.5f);
        GameObject sceneCrystal = GameObject.Find("CellBossCrystal(Clone)");
        CancelInvoke();
        currentPhase = Phase.one;
        yield return new WaitForSeconds(1f);
        col.enabled = true;
        Destroy(sceneCrystal.gameObject);
    }
    private void SpawnSpikes() {
        if(currentPhase == Phase.two) {
            foreach (var item in shootPos) {
                Instantiate(spike, item.transform.position, item.transform.rotation);
            }
        }
    }
    private void SpawnCrystal() {
        if(transform.position.x < 0) {
            randPos = new Vector2(Random.Range(2f, 6f), Random.Range(-2f, 2f));
            Instantiate(crystal, randPos, Quaternion.identity);
        } else {
            randPos = new Vector2(Random.Range(-2f, -6f), Random.Range(-2f, 2f));
            Instantiate(crystal, randPos, Quaternion.identity);
        }
        col.enabled = false;
        currentPhase = Phase.two;
    }
    private void SpawnCells() {
        if(currentPhase == Phase.three) {
            if (leftSide) {
                randPos = new Vector2(-7.25f, Random.Range(2.5f, -2.5f));
                Instantiate(cell, randPos, Quaternion.identity);
                leftSide = false;
            } else {
                randPos = new Vector2(7.25f, Random.Range(2.5f, -2.5f));
                Instantiate(cell, randPos, Quaternion.identity);
                leftSide = true;
            }
        }
    }
    public void Explosion() {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    protected override void Dying() {
        base.Dying();
        if (Health <= 0) {
            GameObject[] cells = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in cells) {
                GameObject.Destroy(obj);
            }
        }
    }
}
