using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPos;
    public Transform BossPos;
    public List<GameObject> enemyList = new List<GameObject>();
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    [Header("Timer")]
    public Text timerText;

    public int timer = 0;
    private float spawnCount = 1f;

   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy_());
        StartCoroutine(TimerCoroution());
    }


    IEnumerator SpawnEnemy_()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnCount);
            Transform spawnPoint = spawnPos[Random.Range(0, 7)];
            int spawnNum1 = Random.Range(0, 2);
            int spawnNum2 = Random.Range(1, 3);
            int spawnNum3 = Random.Range(0, 4);

            if (timer <= 30)
            {
                GameObject newEnemy = Instantiate(enemyList[0], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 30 && timer <= 45)
            {
                GameObject newEnemy = Instantiate(enemyList[spawnNum1], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 45 && timer <= 60)
            {
                GameObject newEnemy = Instantiate(enemyList[1], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 60 && timer <= 75)
            {
                GameObject newEnemy = Instantiate(enemyList[spawnNum2], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 75 && timer <= 90)
            {
                GameObject newEnemy = Instantiate(enemyList[2], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 90 && timer <= 105)
            {
                GameObject newEnemy = Instantiate(enemyList[spawnNum3], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 105 && timer <= 120)
            {
                GameObject newEnemy = Instantiate(enemyList[3], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 120 && timer <= 180)
            {
                spawnCount = 0.5f;
                GameObject newEnemy = Instantiate(enemyList[spawnNum3], spawnPoint.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(spawnPoint);
                spawnedEnemies.Add(newEnemy);
            }
            else if (timer > 180)
            {
                spawnCount = 300f;
                GameObject newEnemy = Instantiate(enemyList[4], BossPos.position, Quaternion.identity);
                newEnemy.GetComponent<EnemyOne>().MonsterRandomAnim();
                newEnemy.transform.SetParent(BossPos);
                spawnedEnemies.Add(newEnemy);
                StopCoroutine(SpawnEnemy_());
            }
        

        }
    }

    public void ApplyDamageToLastSpawnedEnemy(float damage)
    {
        if (spawnedEnemies.Count > 0)
        {
            GameObject lastEnemy = spawnedEnemies[spawnedEnemies.Count - 1];
            EnemyOne enemyScript = lastEnemy.GetComponent<EnemyOne>();
            if (enemyScript != null)
            {
                enemyScript.EnemyTakeDamage(damage);
            }
        }
    }

    IEnumerator TimerCoroution()
    {
        timer += 1;

        timerText.text = (timer / 60 % 60).ToString("D2") + ":" + (timer % 60).ToString("D2");

        yield return new WaitForSeconds(1f);

        StartCoroutine(TimerCoroution());
    }

}
