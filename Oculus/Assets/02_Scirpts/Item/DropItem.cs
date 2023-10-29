using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public List<GameObject> DropItemList = new List<GameObject>();

    public GameObject deathEffect;
    public GameObject bossDeathEffect;
    public GameObject endingPotal;

    public static DropItem instance;

    private void Awake()
    {
        instance = this;
    }
    public void RandomItemDrop(Vector3 position)
    {
        int r = Random.Range(0 ,DropItemList.Count + 10);
        switch (r)
        {
            case 0:
                Instantiate(DropItemList[0], position, Quaternion.identity);
                break;
            case 1:
                Instantiate(DropItemList[1], position, Quaternion.identity);
                break;

            default:
                break;
        }
    }

    public void EnemyDeathEffect(Vector3 position)
    {
        GameObject effectInstance = Instantiate(deathEffect, position, Quaternion.identity);
        Destroy(effectInstance, 1.0f);
    }


    public void BossDeathEffect(Vector3 position)
    {
        GameObject effectInstance = Instantiate(bossDeathEffect, position, Quaternion.identity);
        Instantiate(endingPotal, position, Quaternion.identity);
        Destroy(effectInstance, 2.0f);
    }
}
