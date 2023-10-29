using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform target;
    public float y;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, y, target.position.z);
        float playerYRotation = target.eulerAngles.y;
        transform.rotation = Quaternion.Euler(90f, playerYRotation, 0f);
    }

}

