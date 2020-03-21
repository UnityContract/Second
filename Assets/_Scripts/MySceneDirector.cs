using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class MySceneDirector : MonoBehaviour
{
    public static MySceneDirector Instance;

    public PlayableDirector director;

    public AudioSource audioSource;

    double time;
    
    void Awake()
    {
        Instance = this;
    }

    public void Play()
    {
        director.enabled = true;
        director.time = time;
        director.Play();
    }

    public void Pause()
    {
        director.enabled = false;//.Pause();
    }

    public void Seek(double time)
    {
        director.time = time;
        this.time = time;
    }

    public void PlayVoice()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PauseVoice()
    {
        audioSource.Stop();
    }
}
