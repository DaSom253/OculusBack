using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorOpen : MonoBehaviour
{
    public GameObject MainDoorKey;


    public Animator anim;
    public PlayerAudio playerAudio;
    public Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key2"))
        {
            Debug.Log("1");

            anim.SetTrigger("MainDoorOpen");
            playerAudio.Play(PlayerAudio.AudioType.MainDoorOpen, true);
            playerAudio.Play(PlayerAudio.AudioType.Clear, true);
            MainDoorKey.transform.position = targetPosition.position;

            Invoke("PhoneSound", 1.5f);
        }
    }

    void PhoneSound()
    {
        playerAudio.Play(PlayerAudio.AudioType.Phone, true);

    }
}
