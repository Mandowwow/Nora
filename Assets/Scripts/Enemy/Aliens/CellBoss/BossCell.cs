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
    [SerializeField] private GameObject spike = null;
    [SerializeField] private GameObject crystal = null;
    [SerializeField] private GameObject crystalLoc = null;
    [SerializeField] private GameObject[] shootPos = null;
    private Vector3 moveDirection;
    private Vector2 direction;
    private Vector2 center = new Vector2(0,0);
    public Phase currentPhase = Phase.one;

    protected override void Start() {
        base.Start();
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
                
                if(Vector2.Distance(transform.position, center) < 0.1f) {
                    Debug.Log("<color=red> Here </color>");
                    transform.Rotate(new Vector3(0f, 0f, 148f) * Time.deltaTime);
                    StartCoroutine(Spawn());
                    //transform.up = direction;
                } else {
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
        if(Health == 30) {            
            Instantiate(crystal, crystalLoc.transform.position, crystalLoc.transform.rotation);
            currentPhase = Phase.two;
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

    private IEnumerator Spawn() {
        foreach (var item in shootPos) {
            Instantiate(spike, item.transform.position, item.transform.rotation);
        }
        yield return new WaitForSeconds(3.5f);
        currentPhase = Phase.one;
        Destroy(crystal.gameObject);
    }
}
