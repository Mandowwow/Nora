using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private bool playAnim = true;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playAnim) {
            StartCoroutine(WaitAnim());
        }
    }

    private IEnumerator WaitAnim() {
        playAnim = false;
        int randomWait = Random.Range(0, 10);
        yield return new WaitForSeconds(randomWait);
        anim.Play("Blink" , 0, 0f);
        playAnim = true;
    }
}
