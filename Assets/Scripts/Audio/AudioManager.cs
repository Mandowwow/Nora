using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private List<AudioSource> audioSources = new List<AudioSource>();
    public static AudioManager instance;
    public static string lastSongPlayed;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            // Add the AudioSource to the audioSources list
            audioSources.Add(s.source);
        }
    }

    private void Start() {
        Play("MainMenu");
    }

    public void Play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        lastSongPlayed = name;
        s.source.Play();
    }

    public void StopMusic(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }

    public void StopAllAudio() {
        foreach (var audioSource in audioSources) {
            if (audioSource != null && audioSource.isPlaying) {
                audioSource.Stop();
            }
        }
    }
}
