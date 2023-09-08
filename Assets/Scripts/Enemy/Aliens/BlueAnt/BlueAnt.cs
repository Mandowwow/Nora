using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAnt : Enemy
{
    [SerializeField] private GameObject spit = null;
    [SerializeField] private GameObject barrel = null;
    [SerializeField] private GameObject ball = null;
    private Animator anim;

    protected override void Start() {
        base.Start();
        anim = GetComponent<Animator>();
        InvokeRepeating("DealDmg", 1f, 4f);
    }

    public void Spit() {
        //Projectile Attack
        Instantiate(ball, barrel.transform.position, Quaternion.identity);
    }

    public void DealDmg() {
        anim.Play("Spit");
    }
}
