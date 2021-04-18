using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAssets : MonoBehaviour
{
    private static AudioAssets _instance;

    public static AudioAssets instance
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("Sounds/AudioAssets")) as GameObject).GetComponent<AudioAssets>();
           
            return _instance;
        }
        
    }

    public SoundAudioClip[] soundAudioClips;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.SoundType sound;
        public AudioClip audioClip;
    }
}
