using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Frame : MonoBehaviour
{

    public GameObject I;
    public GameObject I_;


    public Transform targetPosition;

    public PlayerAudio playerAudio;

    private void OnCollisionEnter(Collision collision)
    {
        // Access the name of the object colliding with this game object
        if (collision.gameObject.name == "I")
        {
            I.transform.position = targetPosition.position;
            
            I_.gameObject.SetActive(true);
            InstanceManager.s.I_Block = true;
            playerAudio.Play(PlayerAudio.AudioType.Alphabet, true);

        }
    }
}
