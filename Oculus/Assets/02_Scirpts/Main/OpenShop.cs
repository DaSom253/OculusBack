using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public StatShop statShop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            statShop.OpenShop();
            //MouseControll.instance.unLock();
            statShop.Shop.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.audioManager.Play(AudioManager.AudioType.ShopOpen, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        statShop.BackShopBtn();
        //MouseControll.instance.Lock();
        statShop.Shop.SetActive(false);
        GameManager.instance.audioManager.Play(AudioManager.AudioType.ShopClose, true);

    }
}
