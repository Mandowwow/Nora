using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    private static bool music = true;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start() {
        if(music == true) {
            source.PlayOneShot(clip);
            music = false;
        }
    }
}
