using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetFrame : MonoBehaviour
{
    
    public GameObject J;
    public GameObject J_;

    public Transform targetPosition;


    public PlayerAudio playerAudio;

    private void OnCollisionEnter(Collision collision)
    {
        // Access the name of the object colliding with this game object
        if (collision.gameObject.name == "J")
        {
            J.transform.position = targetPosition.position;
            J_.gameObject.SetActive(true);
            InstanceManager.s.J_Block = true;
            playerAudio.Play(PlayerAudio.AudioType.Alphabet, true);

        }
    }
}
