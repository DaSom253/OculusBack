using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBox : MonoBehaviour
{
    public GameObject closet;
    public GameObject Ball;
    public Transform targetPosition;

    public PlayerAudio playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball.transform.position = targetPosition.position;

            closet.gameObject.GetComponent<Animator>().SetTrigger("ClosetOpen");
            playerAudio.Play(PlayerAudio.AudioType.Clear, true);



        }
    }
}
