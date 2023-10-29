using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class U_Frame : MonoBehaviour
{

    public GameObject U;
    public GameObject U_;

    public Transform targetPosition;
    public PlayerAudio playerAudio;

    private void OnCollisionEnter(Collision collision)
    {
        // Access the name of the object colliding with this game object
        if (collision.gameObject.name == "U")
        {
            U.transform.position = targetPosition.position;

            U_.gameObject.SetActive(true);
            InstanceManager.s.U_Block = true;
            playerAudio.Play(PlayerAudio.AudioType.Alphabet, true);

        }
    }
}
