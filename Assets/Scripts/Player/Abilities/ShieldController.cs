using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : AbilityController
{
    private Vector3 pos;
    public GameObject shield;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        shield = GameObject.FindGameObjectWithTag("Shield");
        //pos = GameObject.FindGameObjectWithTag("Shield").GetComponent<Transform>().position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Activate() {
        base.Activate();
        shield.SetActive(true);
    }
}
