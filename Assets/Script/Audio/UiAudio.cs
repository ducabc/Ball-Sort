using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAudio : MonoBehaviour
{
    public Slider musicSlider, audioSlider;

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }
    public void AudioVolume()
    {
        AudioManager.Instance.MusicVolume(audioSlider.value);
    }
}
