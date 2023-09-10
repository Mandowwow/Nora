using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnt : Enemy
{
    [SerializeField] private GameObject spit = null;
    [SerializeField] private GameObject barrel = null;
    [SerializeField] private GameObject ball = null;
    [SerializeField] private GameObject blueThunder = null;
    [SerializeField] private GameObject[] randPos = null;
    private int rand = 0;
    private Animator anim;

    protected override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
        InvokeRepeating("DealDmg", 1f, 4f);
        InvokeRepeating("BlueThunder", 10f, 10f);
        randPos = GameObject.FindGameObjectsWithTag("RandPos");
    }

    public void Spit() {
        //Projectile Attack
        Instantiate(ball, barrel.transform.position, Quaternion.identity);
    }

    public void DealDmg() {
        anim.Play("Spit");
    }

    public void BlueThunder() {
        rand = Random.Range(0, randPos.Length);
        Instantiate(blueThunder, randPos[rand].transform.position, Quaternion.identity);
    }

    protected override void Dying() {
        base.Dying();
        if(Health <= 0) {
            GameObject[] ball = GameObject.FindGameObjectsWithTag("Slime");
            foreach (GameObject obj in ball) {
                GameObject.Destroy(obj);
            }
        }
    }
}
