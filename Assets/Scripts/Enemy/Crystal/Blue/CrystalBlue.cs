using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBlue : Enemy
{
    [SerializeField]
    GameObject prefab;
    Animator anim;
    Phase currentPhase = Phase.Phase1;

    float timer = 0f;
    float interval = 1f;

    public enum Phase {
        Phase1,
        Phase2
    }

    protected override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
        StartCoroutine(Wait());
    }
    protected override void ChasePlayer() {
        if(currentPhase == Phase.Phase1) {
            base.ChasePlayer();
            TurnDirection();
        }
    }
    protected override void Attack() {
        if(currentPhase == Phase.Phase2) {
            timer += Time.deltaTime;
            if (timer >= interval) {
                BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.down);
                BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.down);
                BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, 0) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, 0) * Vector3.down);
                BlowUp(Quaternion.Euler(0, 0, 90) * Vector3.up);
                BlowUp(Quaternion.Euler(0, 0, 90) * Vector3.down);
                timer = 0f;
            }
        }
    }
    private void TurnDirection() {
        if (player != null) {
            if (transform.position.x > player.transform.position.x) {
                sprite.flipX = false;
            }
            else {
                sprite.flipX = true;
            }
        }
    }
    protected override void Dying() {
        if (health <= 0) {
            BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.down);
            BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.down);
            BlowUp(Quaternion.Euler(0, 0, 45) * Vector3.up);
            BlowUp(Quaternion.Euler(0, 0, -45) * Vector3.up);
            BlowUp(Quaternion.Euler(0,0,0) * Vector3.up);
            BlowUp(Quaternion.Euler(0,0,0) * Vector3.down);
            BlowUp(Quaternion.Euler(0,0,90) * Vector3.up);
            BlowUp(Quaternion.Euler(0,0,90) * Vector3.down);
            Destroy(this.gameObject);
            FindEnemies.Enemies.Remove(this.gameObject);
            if (FindEnemies.Enemies.Count <= 0) {
                Instantiate(findEnemies.Portal, new Vector3(0, 0, 0), Quaternion.identity);
                GameManager.instance.StartLevelUp();
            }

        }
    }
    private void BlowUp(Vector3 dir) {
        GameObject spawnedBullet = Instantiate(prefab);
        spawnedBullet.transform.position = transform.position;
        spawnedBullet.GetComponent<CrystalBlue_Ball>().DirectionCalc(dir);
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
    IEnumerator Wait() {
        float rand = Random.Range(1f, 6f);
        yield return new WaitForSeconds(rand);
        anim.Play("Hide");
        currentPhase = Phase.Phase2;
        col.enabled = false;
        float rand2 = Random.Range(5f, 7f);
        yield return new WaitForSeconds(rand2);
        anim.Play("Idle");
        currentPhase = Phase.Phase1;
        col.enabled = true;
    }
}
