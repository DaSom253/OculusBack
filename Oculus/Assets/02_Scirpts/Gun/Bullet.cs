using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public StatShop statShop;

    // Start is called before the first frame update
    void Start()
    {
        GameObject statObject = GameObject.Find("Canvas");
        if (statObject != null)
        {
            statShop = statObject.GetComponent<StatShop>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyOne enemy = other.gameObject.GetComponent<EnemyOne>();
            if (enemy != null)
            {
                enemy.EnemyTakeDamage(0); // 개별 데미지 값을 전달
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        switch (other.gameObject.name)
        {
            case "HealthCube":
                statShop.HealBtn();
                break;
            case "HealCube":
                statShop.HealTimeBtn();
                break;
            case "DamageCube":
                statShop.DamageBtn();
                break;
            case "SpeedCube":
                statShop.SpeedBtn();
                break;
            case "ResetCube":
                statShop.ResetBtn();
                break;



        }
    }

}
