using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVolumeController : MonoBehaviour
{
    public enum AudioType { MUSIC, SFX };
    public AudioType type;

    private AudioSource audioSource;
    private float currentAudioLevel;
    [Range(0, 2)]
    public float defaultAudioLevel;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetAudioLevel(float newAudioLevel)
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
        currentAudioLevel = defaultAudioLevel * newAudioLevel;
        audioSource.volume = currentAudioLevel;
    }
}
