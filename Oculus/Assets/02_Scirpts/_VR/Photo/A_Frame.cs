using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Frame : MonoBehaviour
{

    public GameObject A;
    public GameObject A_;


    public Transform targetPosition;

    public PlayerAudio playerAudio;

    private void OnCollisionEnter(Collision collision)
    {
        // Access the name of the object colliding with this game object
        if (collision.gameObject.name == "A")
        {
            A.transform.position = targetPosition.position;

            A_.gameObject.SetActive(true);
            InstanceManager.s.A_Block = true;
            playerAudio.Play(PlayerAudio.AudioType.Alphabet, true);

        }
    }
}
