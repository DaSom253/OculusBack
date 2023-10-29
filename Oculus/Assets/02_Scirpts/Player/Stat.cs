using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int hpUp; //기본 체력 증가
    public int hpTimeHeal; //시간마다 체력 회복
    public float damageUp; //공격력 증가
    public float moveSpeedUp; //이동속도 증가

    // Start is called before the first frame update
    void Start()
    {
        DataLoad();
        StartCoroutine(StatSet());
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HpTiemHeal();
    }


    public void HpUp()
    {
        Player.instance.hp += 200f * hpUp;
        Player.instance.maxHp = Player.instance.hp;
    }

    public void HpTiemHeal()
    {
        if(GameManager.instance.player.maxHp >= GameManager.instance.player.hp)
        {
            GameManager.instance.player.hp += 5f * hpTimeHeal * Time.deltaTime;
        }
    }

    public void DamagedUp()
    {
        Player.instance.damage += 2.5f * damageUp;
    }

    public void MoveSpeedUp()
    {
        OVRPlayerController.instance.Acceleration += 0.1f * moveSpeedUp;
    }

    void DataLoad()
    {
        DataManager.instance.LoadData();
        hpUp = DataManager.instance.playerData.hpUp;
        hpTimeHeal = DataManager.instance.playerData.hpTimeHeal;
        damageUp = DataManager.instance.playerData.damageUp;
        moveSpeedUp = DataManager.instance.playerData.moveSpeedUp;
    }

    IEnumerator StatSet()
    {
        yield return new WaitForEndOfFrame();
        HpUp();
        DamagedUp();
        MoveSpeedUp();
    }
}
