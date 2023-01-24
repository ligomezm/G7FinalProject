using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip audioClip;

    private void Start()
    {

        StartCoroutine(PrepareMusic());
    }

    IEnumerator PrepareMusic()
    {
        yield return new WaitForSeconds(.5f);
        SoundManager.GetInstance().PlayMusic(audioClip);

    }
}
