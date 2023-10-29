using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    public Rigidbody prefabBullet;
    public Transform BulletPos;

    public PlayerAudio playerAudio;



    // Start is called before the first frame update

    private void Awake()
    {
    }


    // Update is called once per frame
    void Update()
    {
    }




    public void CheckGun()
    {

            Rigidbody bulletRb =
                Instantiate(prefabBullet, BulletPos.position, BulletPos.localRotation);

            bulletRb.velocity = -20.0f * transform.right;

        playerAudio.Play(PlayerAudio.AudioType.Gun, true);
    }



 

}