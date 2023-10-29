using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowAoe : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyOne enemy = other.gameObject.GetComponent<EnemyOne>();
            if (enemy != null)
            {
                StartCoroutine(TakeDamage(enemy));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyOne enemy = other.gameObject.GetComponent<EnemyOne>();

        StopCoroutine(TakeDamage(enemy));
    }

    IEnumerator TakeDamage(EnemyOne enemy)
    {
        enemy.EnemyTakeDamage(-2f); // 개별 데미지 값을 전달
        yield return new WaitForSeconds(1f);
        enemy.EnemyTakeDamage(-2f); // 개별 데미지 값을 전달
        yield return new WaitForSeconds(1f);
        enemy.EnemyTakeDamage(-2f); // 개별 데미지 값을 전달
        yield return new WaitForSeconds(1f);
        enemy.EnemyTakeDamage(-2f); // 개별 데미지 값을 전달
    }

}
