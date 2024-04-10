using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brown_Spit : Enemy
{
    [SerializeField] private GameObject spit = null;
    [SerializeField] private GameObject barrel = null;
    private Animator anim;
    protected override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected override void ChasePlayer() {
        if (player != null) {
            if (Vector2.Distance(transform.position, player.position) >= 0f) {
                anim.Play("Spit");
            }
        }
    }

    public void Spit() {
        CreatePrefab(Quaternion.Euler(0, 0, 45) * Vector3.down);
        CreatePrefab(Quaternion.Euler(0, 0, 0) * Vector3.down);
        CreatePrefab(Quaternion.Euler(0, 0, -45) * Vector3.down);
    }

    public void CreatePrefab(Vector3 dir) {
        if (Vector2.Distance(transform.position, player.position) < 13f) {
            GameObject spawnedPrefab = Instantiate(spit);
            spawnedPrefab.transform.position = barrel.transform.position;
            spawnedPrefab.GetComponent<Brown_SpitBall>().DirectionCalc(dir);

        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Controller") && Time.time > nextFire) {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
            nextFire = Time.time + fireRate;
        }
    }
}
