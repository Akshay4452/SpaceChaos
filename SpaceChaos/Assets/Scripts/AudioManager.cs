using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(musicSounds, s => s.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
        } 
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX (string name)
    {
        Sounds s = Array.Find(sfxSounds, s => s.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

}
