using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatShop : MonoBehaviour
{
    public GameObject Shop;

    public int shopCoin; //코인
    public Text shopCoinText;
    public Sprite ChangeImage;
    
    [Header("Stat")]
    public List<Image> Heal = new List<Image>();
    public int healCount;

    public List<Image> HealTime = new List<Image>();
    public int healTimeCount;

    public List<Image> Damage = new List<Image>();
    public int damagedCount;

    public List<Image> Speed = new List<Image>();
    public int speedCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        shopCoinText.text = shopCoin.ToString();

        UpdateStatImages(Heal, healCount);
        UpdateStatImages(HealTime, healTimeCount);
        UpdateStatImages(Damage, damagedCount);
        UpdateStatImages(Speed, speedCount);
    }

    private void StatLoadData()
    {
        healCount = DataManager.instance.playerData.hpUp;
        healTimeCount = DataManager.instance.playerData.hpTimeHeal;
        damagedCount = DataManager.instance.playerData.damageUp;
        speedCount = DataManager.instance.playerData.moveSpeedUp;
    }

    private void StatSaveData()
    {
        DataManager.instance.playerData.coin = shopCoin;
        DataManager.instance.playerData.hpUp = healCount;
        DataManager.instance.playerData.hpTimeHeal = healTimeCount;
        DataManager.instance.playerData.damageUp = damagedCount;
        DataManager.instance.playerData.moveSpeedUp = speedCount;
    }

    #region Btn

    public void GameStartBtn()
    {
        SceneManager.LoadScene("SS");
    }

    public void HealBtn()
    {
        if(healCount < 6)
        {
            if(shopCoin > 99)
            {
                shopCoin -= 100;
                healCount += 1;
                DataManager.instance.playerData.hpUp += healCount;
                GameManager.instance.audioManager.Play(AudioManager.AudioType.StatUp, true);
            }
            else
            {
                Debug.Log("돈 부족");
            }

        }
        
    }

    public void HealTimeBtn()
    {
        if (healTimeCount < 6)
        {
            if (shopCoin > 99)
            {
                shopCoin -= 100;
                healTimeCount += 1;
                DataManager.instance.playerData.hpUp += healTimeCount;
                GameManager.instance.audioManager.Play(AudioManager.AudioType.StatUp, true);
            }
            else
            {
                Debug.Log("돈 부족");
            }
        }
    }

    public void DamageBtn()
    {
        if (damagedCount < 6)
        {
            if (shopCoin > 99)
            {
                shopCoin -= 100;
                damagedCount += 1;
                DataManager.instance.playerData.hpUp += damagedCount;
                GameManager.instance.audioManager.Play(AudioManager.AudioType.StatUp, true);
            }
            else
            {
                Debug.Log("돈 부족");
            }
        }
    }

    public void SpeedBtn()
    {
        if (speedCount < 6)
        {
            if (shopCoin > 99)
            {
                shopCoin -= 100;
                speedCount += 1;
                DataManager.instance.playerData.hpUp += speedCount;
                GameManager.instance.audioManager.Play(AudioManager.AudioType.StatUp, true);
            }
            else
            {
                Debug.Log("돈 부족");
            }
        }
    }

    public void BackShopBtn()  // 뒤로가기 버튼 세이브할 거 여기에 넣기
    {
        if (Shop.activeSelf)
        {
            StatSaveData();
            DataManager.instance.SaveData();
            Shop.SetActive(false);
        }
    }

    public void ResetBtn()
    {
        GameManager.instance.audioManager.Play(AudioManager.AudioType.StatReset, true);
        shopCoin += (healCount + damagedCount + healTimeCount + speedCount) * 100;
        healCount = 0;
        damagedCount = 0;
        healTimeCount = 0;
        speedCount = 0;
        DownImage(Damage);
        DownImage(Heal);
        DownImage(HealTime);
        DownImage(Speed);
    }

    #endregion

    public void OpenShop()
    {
        if (!Shop.activeSelf)
        {
            Shop.SetActive(true);
            DataManager.instance.LoadData();
            StatLoadData();
            shopCoin = DataManager.instance.playerData.coin;
        }
    }

    private void UpdateStatImages(List<Image> statImages, int count)
    {
        for (int i = 0; i < statImages.Count; i++)
        {
            statImages[i].sprite = i < count ? ChangeImage : null;
        }
    }

    private void DownImage(List<Image> statImages)
    {
        for (int i = 0; i < statImages.Count; i++)
        {
            statImages[i].sprite = null;
        }
    }
}
