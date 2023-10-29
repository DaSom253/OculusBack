using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPayerAudio : MonoBehaviour
{
    // MainPayerAudio.Play(MainPayerAudio.AudioType.Attack, true);

    [SerializeField] AudioSource BookSound = null;
    [SerializeField] AudioSource EndingBGMSound = null;

    public enum AudioType
    {
        Book, EndingBGM
    }

    public void Play(AudioType audioType, bool playState)
    {
        AudioSource audioSource = null;
        switch (audioType)
        {
            case AudioType.Book:
                audioSource = BookSound;
                break;
            case AudioType.EndingBGM:
                audioSource = EndingBGMSound;
                break;
        }

        if (audioSource != null)
        {
            if (playState)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}
