using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    public GameObject[] stars;
    private int index = 0;
    // Start is called before the first frame update
    void Start() {
        ShuffleArray(stars);
        InvokeRepeating("StarTransform", 3f, 4f);
    }

    private void StarTransform() {
        stars[index].GetComponent<Star>().anim.Play("Transform");
        StartCoroutine(Wait());
        ChangeStarPhase();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1f);
        stars[index].GetComponent<Star>().speed = Random.Range(1.5f, 2.25f);
        if (index < stars.Length - 1) {
            index++;
        }
    }

    void ShuffleArray(GameObject[] array) {
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            GameObject temp = array[k];
            array[k] = array[n];
            array[n] = temp;
        }
    }

    void ChangeStarPhase() {
        if (index == stars.Length - 1) {
            for (int i = 0; i < stars.Length; i++) {
                stars[i].GetComponent<Star>().chase = false;
            }
        }
    }
}
