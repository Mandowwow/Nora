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
    [SerializeField] private GameObject[] shootPos = null;
    [SerializeField] private GameObject[] crystalLocations = null;
    private int rand = 0;
    private float randF = 0f;
    private Vector3 moveDirection;
    private Vector2 direction;
    private Vector2 center = new Vector2(0,0);
    public Phase currentPhase = Phase.one;

    protected override void Start() {
        base.Start();
        InvokeRepeating("SpawnCells", 1, 5);
    }
    protected override void ChasePlayer() {
        switch (currentPhase) {
            case Phase.one:
                base.ChasePlayer();
                Vector3 playerPos = player.transform.position;
                direction = new Vector2(
                    playerPos.x - transform.position.x,
                    playerPos.y - transform.position.y);
                transform.up = direction;
                break;
            case Phase.two:
                if (Vector2.Distance(transform.position, center) < 0.1f) {
                    Debug.Log("<color=red> Here </color>");
                    transform.Rotate(new Vector3(0f, 0f, 148f) * Time.deltaTime);
                    StartCoroutine(SpawnSpikes());
                    //transform.up = direction;
                }
                else {
                    Vector3 directionPos = center;
                    direction = new Vector2(
                       directionPos.x - transform.position.x,
                       directionPos.y - transform.position.y);
                    transform.up = direction;
                    transform.position = Vector2.MoveTowards(transform.position, center, speed * Time.fixedDeltaTime);
                }
                break;
            case Phase.three:

                break;
            default:
                break;
        }
        
    }
    public override void TakeDamage(int damage) {
        base.TakeDamage(damage);
        if(Health == 50) {
            SpawnCrystal(RandomNumber(0,4));
        } else if (Health == 40) {
            SpawnCrystal(RandomNumber(0,4));
        } else if (Health == 30) {
            SpawnCrystal(RandomNumber(0,4));
        } else if (Health == 20) {
            SpawnCrystal(RandomNumber(0,4));
        } else if (Health == 10) {
            currentPhase = Phase.three;
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
    private IEnumerator SpawnSpikes() {
        foreach (var item in shootPos) {
            Instantiate(spike, item.transform.position, item.transform.rotation);
        }
        yield return new WaitForSeconds(3.5f);
        GameObject sceneCrystal = GameObject.Find("CellBossCrystal(Clone)");
        currentPhase = Phase.one;
        yield return new WaitForSeconds(1f);
        Destroy(sceneCrystal.gameObject);
    }
    private void SpawnCrystal(int rand) {
        Instantiate(crystal, crystalLocations[rand].transform.position, crystalLocations[rand].transform.rotation);
        currentPhase = Phase.two;
    }
    private void SpawnCells() {
        if(currentPhase == Phase.three) {
            Instantiate(cell, new Vector3(-7, 2, 0), transform.rotation);
        }
    }
    private int RandomNumber(int min, int max) {
       return rand = Random.Range(min, max);
    }
}
