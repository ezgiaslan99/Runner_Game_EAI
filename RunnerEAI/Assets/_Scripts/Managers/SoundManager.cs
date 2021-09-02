using System.Collections;
using System.Collections.Generic;
using Managers;
using Player;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip winSound, winDanceMusic, bodyFall, backgroundAmbiance;
    public AudioSource winMusic,runMusic,superRunMusic,obstacleCrash1,obstacleCrash2;
    void Awake()
    {
        StartSingleton(this);
    }
    void OnEnable()
    {
        MenuManager.OnResetGame += AllResetMusic;    
    }
    void Update()
    {
        switch (GameManager.currentState)
        {
            case GameManager.State.Running:
                RunMusic();
                break;

            case GameManager.State.Jump:
                AllResetMusic();
                break;

            case GameManager.State.SuperRunning:
                SuperRunMusic();
            break;

            case GameManager.State.Win:
                WinMusic();
                break;
        }    
    }
   public void ObstacleCrashMusic()
    {   
        AllResetMusic();
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            obstacleCrash1.Play();
        }
        else
        {
            obstacleCrash2.Play();
        }
    }
    void RunMusic()
    {
        if (runMusic.isPlaying) 
        {
            return;
        }
        AllResetMusic();
        runMusic.Play();
    }
    void SuperRunMusic()
    {
        if (superRunMusic.isPlaying)
        {
            return;
        }
        AllResetMusic();
        superRunMusic.Play();
    }
    void WinMusic()
    {
        if (winMusic.isPlaying)
        {
            return;
        }
        AllResetMusic();
        winMusic.Play();
    }
    void AllResetMusic() 
    {
        winMusic.Stop();
        runMusic.Stop();
        superRunMusic.Stop();
    }
    // void PlayObstacleCrashSound()
    // {
    //     
    // }
    public void PlayClip(AudioClip soundClip, float vol)
    {
        if (soundClip)
        {
            AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position, vol);
        }
    }
    void PlayFinishLineMusic()
    {
        PlayClip(winDanceMusic, 0.2f);
    }
}
