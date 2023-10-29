using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;


    [Header("Stat")]
    public float maxHp;
    public float hp;
    public float moveSpeed;
    public float damage;

    private void Start()
    {
        GameManager.instance.coin = 0;
        StartCoroutine(SS_());
    }

    private void Awake()
    {
        Player.instance = this;
    }

    private void Update()
    {

    }


    public void Damaged(float EnemyDamage)
    {
        hp -= EnemyDamage;
        if (hp < 0)
        {
            hp = 0;
        }
    }

    public void Heal(float Heal)
    {
        hp += Heal;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }

    IEnumerator SS_()  //재입장시 플레이어 적용이 안될때 건들여야함 시간을 늘려
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.SS = true;
    }
}
