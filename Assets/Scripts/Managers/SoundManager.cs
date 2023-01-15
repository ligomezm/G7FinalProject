using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource musicSource, effectSource; 
    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
    public void PlayClipAtPointRef(AudioClip clip, Vector3 clipTransform)
    {
        //effectSource.playclip
        AudioSource.PlayClipAtPoint(clip, clipTransform, AudioListener.volume);
       // effectSource.PlayClipAtPoint(clip, clipTransform);
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
