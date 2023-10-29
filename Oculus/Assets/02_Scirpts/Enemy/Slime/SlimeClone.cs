using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeClone : MonoBehaviour
{
    public GameObject clone;

    public static SlimeClone instance;

    private void Awake()
    {
        instance = this;
    }

}
