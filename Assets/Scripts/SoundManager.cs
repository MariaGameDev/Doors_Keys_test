using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    private static GameObject soundObject;
    private static AudioSource audioSource;
    public enum SoundType
    {
        Alarm,
        Door,
        KeyPick
    }
    public static void PlaySound(SoundType sound)
    {
        if (soundObject == null)
        {
            soundObject = new GameObject("Sound");
            audioSource = soundObject.AddComponent<AudioSource>();
        }
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(SoundType sound)
    {
        foreach (AudioAssets.SoundAudioClip soundAudioClip in AudioAssets.instance.soundAudioClips)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        return null;
    }


}
