using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private CharacterStats stats;
    private int damage;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    private Collider2D col;
    private SpriteRenderer player;

    private PlayerStats ps;

    private void Start() {
        stats = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharacterStats>();
        col = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        player = GetComponent<SpriteRenderer>();
        ps = FindObjectOfType<PlayerStats>();
    }

    private void Update() {

        if(PlayerStats.CurrentHealth <= 0) {
            Debug.Log("dead");
            Destroy(this.gameObject);
        }

        if(PlayerStats.CurrentHealth > ps.CurrentNumOfHearts) {
            PlayerStats.CurrentHealth = ps.CurrentNumOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) {

            if (i < PlayerStats.CurrentHealth) {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < ps.CurrentNumOfHearts) {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int dmg) {
        //if(CharacterStats.Shield == false) {
        //    damage += 1;
        //    if(damage > 1) {
        //        return;
        //    }
        //    CharacterStats.Health = CharacterStats.Health - dmg;
        //    StartCoroutine(Change());
        //}

        PlayerStats.CurrentHealth -= dmg;
        StartCoroutine(Change());
    }

    IEnumerator Change() {
        col.enabled = false;
        player.color = Color.red;
        yield return new WaitForSeconds(1f);
        damage = 0;
        player.color = Color.white;        
        col.enabled = true;
    }
}
