using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Phone : MonoBehaviour
{
    public PlayerAudio playerAudio;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("GrabR") || collision.gameObject.CompareTag("GrabL"))
        {

            Invoke("Time", 0.6f);

            Invoke("Fade", 3f);


            Invoke("Ending", 4f);

        }
    }

    void Ending()
    {
        SceneManager.LoadScene("Ending");
    }

    void Time()
    {
        playerAudio.Play(PlayerAudio.AudioType.Phone, false);
        playerAudio.Play(PlayerAudio.AudioType.TakePhone, true);
    }

    void Fade()
    {
        OVRScreenFade.instance.FadeIn2();

    }
}
