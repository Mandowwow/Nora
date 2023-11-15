using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishLaser : MonoBehaviour
{
    private Transform player;
    private bool canLook = true;
    private Vector2 direction;
    [SerializeField] private GameObject laserPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Invoke("StopLooking", 2f);
        Invoke("Shoot", 3f);
        Destroy(this.gameObject, 3.01f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canLook) {
            CalcDirection();
        }       
    }

    private void CalcDirection() {
        Vector3 playerPos = player.transform.position;

        direction = new Vector2(
        playerPos.x - transform.position.x,
        playerPos.y - transform.position.y);
        transform.right = direction;
    }

    private void StopLooking() {
        canLook = false;
    }

    private void Shoot() {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.transform.up = direction;
        laser.GetComponent<Rigidbody2D>().velocity = direction.normalized * 40f;
    }
}
