using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private CharacterStats stats;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    private Collider2D col;
    private SpriteRenderer player;

    private void Start() {
        stats = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharacterStats>();
        col = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        player = GetComponent<SpriteRenderer>();
    }

    private void Update() {

        if(CharacterStats.Health <= 0) {
            Destroy(this.gameObject);
        }

        if(CharacterStats.Health > CharacterStats.NumOfHearts) {
            CharacterStats.Health = CharacterStats.NumOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) {

            if(i < CharacterStats.Health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if(i < CharacterStats.NumOfHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int dmg) {
        if(CharacterStats.Shield == false) {
            CharacterStats.Health = CharacterStats.Health - dmg;
            StartCoroutine(Change());
        }
    }

    IEnumerator Change() {
        col.enabled = false;
        player.color = Color.red;
        yield return new WaitForSeconds(1f);
        player.color = Color.white;        
        col.enabled = true;
    }
}
