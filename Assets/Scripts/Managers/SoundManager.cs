using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource musicSource, effectSource;
    string currentLevelName;

    private void Start()
    {
        currentLevelName = SceneManager.GetActiveScene().ToString();
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip musicClip)
    {
        // if (SceneManager.GetActiveScene().name == "Level2");
        musicSource.clip = musicClip;
        musicSource.Play();
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
