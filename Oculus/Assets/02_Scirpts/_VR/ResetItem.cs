using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetItem : MonoBehaviour
{
    //private Vector3 originalPosition;
    public Transform targetPosition;
    private bool isReturning;
    private Rigidbody rigid;

    public PlayerAudio playerAudio;

    private void Start()
    {
        //originalPosition = transform.position;
        isReturning = false;
        rigid = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isReturning = true;
            ReturnToOriginalPosition();
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
            playerAudio.Play(PlayerAudio.AudioType.Reset, true);
        }
    }

    private void Update()
    {
        if (isReturning)
        {
            ReturnToOriginalPosition();
        }
    }

    private void ReturnToOriginalPosition()
    {
        transform.position = targetPosition.position;
        isReturning = false;
    }
}
