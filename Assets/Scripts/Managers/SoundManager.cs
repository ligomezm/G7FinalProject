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
}
