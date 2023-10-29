using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.instance.Damaged(enemy_Damage);
        }
    }

}

