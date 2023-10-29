using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public GameObject KeyPad;

    public static Keypad s;

    public bool KeyPad_Col_Open = false;

    private void Awake()
    {
        s = this;
    }

    private void Update()
    {
        //KeyPadOpen();
        //if (KeyPad_Col_Open == false)
        //{
        //    KeyPad.SetActive(false);
        //}
    }

    public void KeyPadOpen()
    {
        if (KeyPad_Col_Open == true)
        {
            KeyPad.SetActive(true);
            if (OVRInput.GetDown(OVRInput.Button.Three))
            {
                KeyPad_Col_Open = false;
            }
        }
    }
}
