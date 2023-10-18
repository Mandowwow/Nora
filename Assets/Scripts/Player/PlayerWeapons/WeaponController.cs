using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //Shooting Variables
    private float nextFire = 0f;
    bool canShoot = true;
    bool canSlime = true;
    bool canBat = true;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject batPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject charge;
    [SerializeField] private Transform shootU;
    [SerializeField] private Transform shootD;
    [SerializeField] private Transform shootL;
    [SerializeField] private Transform shootR;

    private void Update() {
        switch (CharacterStats.CurrentWeapon) {
            case CharacterStats.Weapon.Gun:
                if (Input.GetKey("right") && Time.time > nextFire || Input.GetKey("joystick button 1") && Time.time > nextFire && canShoot) {
                    Shoot(shootR);
                }
                else if (Input.GetKey("left") && Time.time > nextFire || Input.GetKey("joystick button 2") && Time.time > nextFire && canShoot) {
                    Shoot(shootL);
                }
                else if (Input.GetKey("down") && Time.time > nextFire || Input.GetKey("joystick button 0") && Time.time > nextFire && canShoot) {
                    Shoot(shootD);
                }
                else if (Input.GetKey("up") && Time.time > nextFire || Input.GetKey("joystick button 3") && Time.time > nextFire && canShoot) {
                    Shoot(shootU);
                }
                break;

            case CharacterStats.Weapon.Lazer:
                if (Input.GetKey("right") && Time.time > nextFire && canShoot || Input.GetKey("joystick button 1") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootR));
                }
                else if (Input.GetKey("left") && Time.time > nextFire && canShoot || Input.GetKey("joystick button 2") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootL));
                }
                else if (Input.GetKey("down") && Time.time > nextFire && canShoot || Input.GetKey("joystick button 0") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootD));
                }
                else if (Input.GetKey("up") && Time.time > nextFire && canShoot || Input.GetKey("joystick button 3") && Time.time > nextFire && canShoot) {
                    StartCoroutine(LazerShoot(shootU));
                }
                break;

            case CharacterStats.Weapon.Slime:
                if (canSlime) {
                    StartCoroutine(SpawnSlime());
                }
                if (Input.GetKey("right") && Time.time > nextFire || Input.GetKey("joystick button 1") && Time.time > nextFire && canShoot) {
                    Shoot(shootR);
                }
                else if (Input.GetKey("left") && Time.time > nextFire || Input.GetKey("joystick button 2") && Time.time > nextFire && canShoot) {
                    Shoot(shootL);
                }
                else if (Input.GetKey("down") && Time.time > nextFire || Input.GetKey("joystick button 0") && Time.time > nextFire && canShoot) {
                    Shoot(shootD);
                }
                else if (Input.GetKey("up") && Time.time > nextFire || Input.GetKey("joystick button 3") && Time.time > nextFire && canShoot) {
                    Shoot(shootU);
                }
                break;
            case CharacterStats.Weapon.Bat:
                if (canBat) {
                    StartCoroutine(SpawnBat());
                }
                if (Input.GetKey("right") && Time.time > nextFire || Input.GetKey("joystick button 1") && Time.time > nextFire && canShoot) {
                    Shoot(shootR);
                }
                else if (Input.GetKey("left") && Time.time > nextFire || Input.GetKey("joystick button 2") && Time.time > nextFire && canShoot) {
                    Shoot(shootL);
                }
                else if (Input.GetKey("down") && Time.time > nextFire || Input.GetKey("joystick button 0") && Time.time > nextFire && canShoot) {
                    Shoot(shootD);
                }
                else if (Input.GetKey("up") && Time.time > nextFire || Input.GetKey("joystick button 3") && Time.time > nextFire && canShoot) {
                    Shoot(shootU);
                }
                break;
        }
    }

    private void Shoot(Transform pos) {
        Instantiate(bulletPrefab, pos.position, pos.rotation);
        nextFire = Time.time + CharacterStats.FireRate;
    }

    private IEnumerator LazerShoot(Transform pos) {
        Instantiate(charge, pos.position, pos.rotation, pos);
        canShoot = false;
        yield return new WaitForSeconds(0.45f);
        canShoot = true;
        Instantiate(lazerPrefab, pos.position, pos.rotation, pos);
        nextFire = Time.time + CharacterStats.FireRate;
    }

    private IEnumerator SpawnSlime() {
        canSlime = false;
        yield return new WaitForSeconds(1.5f);
        Instantiate(slime, this.transform.position, transform.rotation);
        canSlime = true;
    }

    private IEnumerator SpawnBat() {
        canBat = false;
        yield return new WaitForSeconds(4f);
        //randPos
        Vector2 randPos = new Vector2(Random.Range(-5.5f, 5.5f), Random.Range(-3f, 0.75f));
        //Instantiate Bat
        Instantiate(batPrefab, randPos, Quaternion.identity);
        canBat = true;
    }
}
