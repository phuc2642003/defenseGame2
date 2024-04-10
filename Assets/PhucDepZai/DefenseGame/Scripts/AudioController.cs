using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }
    [Header("Settings: ")]
    [Range(0f, 1f)]
    public float musicVol = 0.3f;
    [Range(0f, 1f)]
    public float soundVol = 0.3f;

    public AudioSource musicAudioSource;
    public AudioSource soundAudioSource;

    [Header("Music and Sound: ")]
    public AudioClip playerAttack;
    public AudioClip enemyDead;
    public AudioClip gameOver;
    public AudioClip[] backgroundMusics;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = soundAudioSource;
        }
        if (sounds == null || sounds.Length <= 0)
        {
            return;
        }
        int randIndex = Random.Range(0, sounds.Length);
        if (sounds[randIndex])
        {
            aus.PlayOneShot(sounds[randIndex], soundVol);
        }
    }
    public void PlaySound(AudioClip sound, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = soundAudioSource;
        }
        if(sound)
        {
            aus.PlayOneShot(sound, soundVol);
        }    
    }
    public void PlayMusic(AudioClip[] musics)
    {
        if(musicAudioSource==null||musics==null||musics.Length<=0)
        {
            return;
        }
        int randIndex = Random.Range(0, musics.Length);
        if (musics[randIndex])
        {
            musicAudioSource.clip = musics[randIndex];
            musicAudioSource.loop = true;
            musicAudioSource.volume = musicVol;
            musicAudioSource.Play();
        }    
    }  
    public void PlayMusic(AudioClip music)
    {
        if (musicAudioSource == null|| music == null)
        {
            return;
        }
        musicAudioSource.clip = music;
        musicAudioSource.loop = true;
        musicAudioSource.volume = musicVol;
        musicAudioSource.Play();
    }    

    public void setMusicVolume(float vol)
    {
        if (musicAudioSource == null) return;

        musicAudioSource.volume = vol;
    }    
    public void setSoundVolume(float vol)
    {
        if (soundAudioSource == null) return;

        soundAudioSource.volume = vol;
    }  
    public void StopPlayMusic()
    {
        if (musicAudioSource == null) return;

        musicAudioSource.Stop();
    }    
    public void PlayBGMusic()
    {
        PlayMusic(backgroundMusics);
    }    
}
