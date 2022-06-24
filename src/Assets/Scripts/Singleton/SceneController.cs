using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoSingletonGeneric<SceneController>
{
    public AudioSource[] audioList;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(transform.gameObject);
    }
    public void ClickToPlay()
    {        
        audioList[0].Play();
    }

    public void StopAllSounds()
    {
        for (int i = 0; i < 3; i++)
        {
            if (audioList[i].isPlaying)
                audioList[i].Stop();
        }
    }

    public void StopSpecificSound(int i)
    {
        if (audioList[i].isPlaying)
            audioList[i].Stop();
    }

    public void StartSpecificSound(int i)
    {
        audioList[i].Play();
    }
    public void StartSpecificSound(AudioSource _audio)
    {
        _audio.Play();
    }
    public AudioClip GetAudioSource(int i)
    {
        return audioList[i].GetComponent<AudioClip>();
    }

    public void LoadRespectiveScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
