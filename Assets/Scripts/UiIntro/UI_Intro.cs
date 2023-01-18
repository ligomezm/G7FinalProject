using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Intro : MonoBehaviour
{
    private TMP_Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource typingAudioSource;

    Button button;
    string textToWrite;

    private void Awake()
    {
        messageText = transform.Find("Message").GetChild(2).GetComponent<TMP_Text>();
        button = transform.Find("Message").GetChild(3).GetComponent<Button>();
        typingAudioSource = transform.Find("Sound").GetComponent<AudioSource>();

        textToWrite = "Do you remember? You are about to open your first exhibiton in the museum!! <br> <br> Go check the relics and make sure they are in perfect condition to be displayed.";
        button.onClick.AddListener(TaskOnClick);
    }

    private void Start()
    {
        StartSound();
        textWriterSingle = TextWriter.AddWriter_Static(messageText, textToWrite, .05f, true, StopSound);
    }

    private void StartSound()
    {
        typingAudioSource.Play();
    }
    private void StopSound()
    {
        typingAudioSource.Stop();
    }

    void TaskOnClick()
    {
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            textWriterSingle.WriteAllText();
        }
        else
        { 
            // Go to next scene 
            // Or set another message
        }

    }
}

