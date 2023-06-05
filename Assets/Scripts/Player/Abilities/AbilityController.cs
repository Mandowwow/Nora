using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Script for abilities to inherit
/// </summary>
public class AbilityController : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected private GameObject ability;
    [SerializeField] protected private float cooldownDuration = 0f;
    [SerializeField] protected private GameObject player;
    private float currentCooldown = 0;
    private CharacterStats stats;


    // Start is called before the first frame update
    virtual protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Controller");
        stats = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharacterStats>();
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f) {
            Activate();
        }
    }

    virtual protected void Activate() {
        currentCooldown = cooldownDuration;
    }
}
