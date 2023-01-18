using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextWriter : MonoBehaviour
{

    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }

    public static TextWriterSingle AddWriter_Static(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
    }

    private TextWriterSingle AddWriter(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
    {
        TextWriterSingle textWriterSingle = new TextWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters, onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    private void Update()
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                //i--;
            }
        }
    }

    public class TextWriterSingle
    {
        private TMP_Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;
        private Action onComplete;

        public TextWriterSingle(TMP_Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters, Action onComplete)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            this.invisibleCharacters = invisibleCharacters;
            this.onComplete = onComplete;
            characterIndex = 0;
        }

        public bool Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex -1);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex - 1) + "</color>";
                }
                uiText.text = text;

                if (characterIndex >= textToWrite.Length)
                {
                    if (onComplete != null) onComplete();
                    return true;
                }
            }
            return false;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllText()
        {
            uiText.text = textToWrite;
            characterIndex = textToWrite.Length;
            if (onComplete != null) onComplete();
        }

    }

}
