using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController[] audios;
    [Range(0, 1)]
    public float maxVolumeLevel;
    [Range(0, 1)]
    public float currentVolumeLevel;

    private void Start()
    {
        audios = FindObjectsOfType<AudioVolumeController>();
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.SFX);
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.MUSIC);
    }

    public void ChangeGlobalAudioVolume(AudioVolumeController.AudioType audioType)
    {
        if (currentVolumeLevel >= maxVolumeLevel)
        {
            currentVolumeLevel = maxVolumeLevel;
        }

        foreach (AudioVolumeController ac in audios)
        {
            if (ac.type == audioType)
            {
                ac.SetAudioLevel(currentVolumeLevel);
            }
        }
    }

    public void AudioChanged(Slider audioSlider)
    {
        currentVolumeLevel = audioSlider.value;
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.MUSIC);
    }

    public void SFXChanged(Slider audioSlider)
    {
        currentVolumeLevel = audioSlider.value;
        ChangeGlobalAudioVolume(AudioVolumeController.AudioType.SFX);
    }
}
