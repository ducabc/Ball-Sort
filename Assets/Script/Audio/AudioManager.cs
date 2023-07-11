using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] sounds, music;
    public AudioSource audioSource, musicSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, x => x.nameClip == name);

        if (s == null) Debug.Log("not found");
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, x => x.nameClip == name);

        if (s == null) Debug.Log("not found");
        else
        {
            audioSource.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
