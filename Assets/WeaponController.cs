using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //Shooting Variables
    private CharacterStats.Weapon currentWeapon = CharacterStats.Weapon.Lazer;
    private float nextFire = 0f;
    bool canShoot = true;
    bool canSlime = true;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject charge;
    [SerializeField] private Transform shootU;
    [SerializeField] private Transform shootD;
    [SerializeField] private Transform shootL;
    [SerializeField] private Transform shootR;

    private void Update() {
        switch (currentWeapon) {
            case CharacterStats.Weapon.Gun:
                if (Input.GetKey("right") && Time.time > nextFire) {
                    Shoot(shootR);
                }
                else if (Input.GetKey("left") && Time.time > nextFire) {
                    Shoot(shootL);
                }
                else if (Input.GetKey("down") && Time.time > nextFire) {
                    Shoot(shootD);
                }
                else if (Input.GetKey("up") && Time.time > nextFire) {
                    Shoot(shootU);
                }
                break;

            case CharacterStats.Weapon.Lazer:
                if (Input.GetKey("right") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootR));
                }
                else if (Input.GetKey("left") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootL));
                }
                else if (Input.GetKey("down") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootD));
                }
                else if (Input.GetKey("up") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootU));
                }
                break;

            case CharacterStats.Weapon.Slime:
                if (canSlime) {
                    StartCoroutine(SpawnSlime());
                }
                if (Input.GetKey("right") && Time.time > nextFire) {
                    Shoot(shootR);
                }
                else if (Input.GetKey("left") && Time.time > nextFire) {
                    Shoot(shootL);
                }
                else if (Input.GetKey("down") && Time.time > nextFire) {
                    Shoot(shootD);
                }
                else if (Input.GetKey("up") && Time.time > nextFire) {
                    Shoot(shootU);
                }
                break;
        }
    }

    private void Shoot(Transform pos) {
        Instantiate(bulletPrefab, pos.position, pos.rotation);
        nextFire = Time.time + fireRate;
    }

    private IEnumerator LazerShoot(Transform pos) {
        Instantiate(charge, pos.position, pos.rotation, pos);
        canShoot = false;
        yield return new WaitForSeconds(0.45f);
        canShoot = true;
        Instantiate(lazerPrefab, pos.position, pos.rotation, pos);
        nextFire = Time.time + fireRate;
    }

    private IEnumerator SpawnSlime() {
        Instantiate(slime, this.transform.position, transform.rotation);
        canSlime = false;
        yield return new WaitForSeconds(1.5f);
        canSlime = true;
    }
}
