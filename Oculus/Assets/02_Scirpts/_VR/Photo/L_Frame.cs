using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Frame : MonoBehaviour
{

    public GameObject L;
    public GameObject L_;

    public Transform targetPosition;

    public PlayerAudio playerAudio;

    private void OnCollisionEnter(Collision collision)
    {
        // Access the name of the object colliding with this game object
        if (collision.gameObject.name == "L")
        {
            L.transform.position = targetPosition.position;

            L_.gameObject.SetActive(true);
            InstanceManager.s.L_Block = true;
            playerAudio.Play(PlayerAudio.AudioType.Alphabet, true);

        }
    }
}
