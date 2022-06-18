using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundScriptableObj", menuName = "ScriptableObjects/NewAudioList")]
public class SoundClipScriptable : ScriptableObject
{
    public AudioSource backgroundMusic;

    public AudioSource ButtonClick;
}
