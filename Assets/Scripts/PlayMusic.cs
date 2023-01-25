using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip audioClip;

    private void Start()
    {

        StartCoroutine(PrepareMusic());
        StartCoroutine(LoopMusic());
    }

    IEnumerator PrepareMusic()
    {
        yield return new WaitForSeconds(0.3f);
        SoundManager.GetInstance().PlayMusic(audioClip);
        SoundManager.GetInstance().ChangeMasterVolume(0.5f);
    }

    IEnumerator LoopMusic()
    {
        yield return new WaitForSeconds(audioClip.length);
        SoundManager.GetInstance().PlayMusic(audioClip);
        SoundManager.GetInstance().ChangeMasterVolume(0.5f);
    }
}
