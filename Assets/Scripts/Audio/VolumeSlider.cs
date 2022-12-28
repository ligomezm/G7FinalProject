using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    void Start()
    {
        SoundManager.GetInstance().ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => SoundManager.GetInstance().ChangeMasterVolume(val));
    }

}
