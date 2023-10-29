using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetUnder : MonoBehaviour
{
    public Animator anim;
    public PlayerAudio playerAudio;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(InstanceManager.s.A_Block == true && InstanceManager.s.J_Block == true && InstanceManager.s.U_Block == true && InstanceManager.s.L_Block == true && InstanceManager.s.I_Block == true)
        {
            anim.SetTrigger("ClosetUnderOpen");
            playerAudio.Play(PlayerAudio.AudioType.DrawerOpen, true);
            playerAudio.Play(PlayerAudio.AudioType.Clear, true);
            InstanceManager.s.I_Block = false;
        }
    }
}
