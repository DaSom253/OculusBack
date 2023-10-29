using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //GameManager.instance.audioManager.Play(AudioManager.AudioType.Shoot, true);

    [SerializeField] AudioSource shootSound = null;
    [SerializeField] AudioSource snowAoeSound = null;
    [SerializeField] AudioSource shopOpen = null;
    [SerializeField] AudioSource shopClose = null;
    [SerializeField] AudioSource statUp = null;
    [SerializeField] AudioSource statReset = null;
    [SerializeField] AudioSource monsterDamage = null;
    [SerializeField] AudioSource monsterDeath = null;
    [SerializeField] AudioSource heal = null;
    [SerializeField] AudioSource getCoin = null;
    [SerializeField] AudioSource smash = null;
    [SerializeField] AudioSource explosion = null;
    [SerializeField] AudioSource fire = null;


    public enum AudioType
    {
        Shoot, SnowAoe, ShopOpen, ShopClose, StatUp, StatReset, MonsterDamage, MonsterDeath, Heal, GetCoin, Smash, Explosion, Fire
    }


    public void Play(AudioType audioType, bool playState)
    {
        AudioSource audioSource = null;
        switch (audioType)
        {
            case AudioType.Shoot:
                audioSource = shootSound;
                break;
            case AudioType.SnowAoe:
                audioSource = snowAoeSound;
                break;
            case AudioType.ShopOpen:
                audioSource = shopOpen;
                break;
            case AudioType.ShopClose:
                audioSource = shopClose;
                break;
            case AudioType.StatUp:
                audioSource = statUp;
                break;
            case AudioType.StatReset:
                audioSource = statReset;
                break;
            case AudioType.MonsterDamage:
                audioSource = monsterDamage;
                break;
            case AudioType.MonsterDeath:
                audioSource = monsterDeath;
                break;
            case AudioType.GetCoin:
                audioSource = getCoin;
                break;
            case AudioType.Heal:
                audioSource = heal;
                break;
            case AudioType.Smash:
                audioSource = smash;
                break;
            case AudioType.Explosion:
                audioSource = explosion;
                break;
            case AudioType.Fire:
                audioSource = fire;
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
