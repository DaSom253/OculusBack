using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlash : EnemyBase
{
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.instance.Damaged(enemy_Damage);
        }
    }
}
