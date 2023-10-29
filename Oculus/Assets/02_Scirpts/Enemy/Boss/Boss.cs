using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss instacne;

    public GameObject slash;
    public GameObject jumpSkill;
    public GameObject fire;

    private float a;
    private void Awake()
    {
        instacne = this;
    }

    private void Start()
    {
        InvokeRepeating("onSlash", 1f, 3f);
        InvokeRepeating("onJump", 5f, 10f);
        InvokeRepeating("onFire", 8f, 10f);
    }

    void onSlash()
    {
        slash.SetActive(true);
        GameManager.instance.audioManager.Play(AudioManager.AudioType.Smash, true);
        Invoke("offSlash", 0.7f);
    }

    void offSlash()
    {
        slash.SetActive(false);
    }

    void onJump()
    {
        jumpSkill.SetActive(true);
        GameManager.instance.audioManager.Play(AudioManager.AudioType.Explosion, true);
        Invoke("offJump", 2f);
    }

    void offJump()
    {
        jumpSkill.SetActive(false);
    }

    void onFire()
    {
        fire.SetActive(true);
        a = EnemyOne.instance.nav.speed;
        EnemyOne.instance.nav.speed = 0f;
        GameManager.instance.audioManager.Play(AudioManager.AudioType.Fire, true);
        Invoke("offFire", 5f);
    }

    void offFire()
    {
        fire.SetActive(false);
        EnemyOne.instance.nav.speed = a;
    }

}
