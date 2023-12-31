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

    public bool IsMusicPlaying { get; private set; }

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
            IsMusicPlaying = true;
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

    public void SetMusicStatus(bool status)
    {
        IsMusicPlaying = status;
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
