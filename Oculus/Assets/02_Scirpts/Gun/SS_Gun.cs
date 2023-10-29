using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Gun : MonoBehaviour
{
    public GameObject bulletPrefab;  //ÃÑ¾Ë ÇÁ¸®ÆÕ
    public Transform bulletSpawnL;  //ÃÑ¾ËÀÌ »ý¼ºµÇ´Â À§Ä¡
    public Transform bulletSpawnR;  //ÃÑ¾ËÀÌ »ý¼ºµÇ´Â À§Ä¡
    public float bulletSpeed = 20f;  //ÃÑ¾Ë ¼Óµµ
    public float fireRate = 0.5f;  //ÃÑ¾Ë ÄðÅ¸ÀÓ
    private float nextFire;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
        GameManager.instance.audioManager.Play(AudioManager.AudioType.Shoot, true);
            FireL();
        }
    }

    public void FireL()
    {
        // ÃÑ¾Ë ÇÁ¸®ÆÕ »ý¼º
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnL.position, bulletSpawnL.rotation);
        GameManager.instance.audioManager.Play(AudioManager.AudioType.Shoot, true);
        // ÃÑ¾Ë ¹ß»ç
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // 2ÃÊ µÚ¿¡ ÆÄ±«
        Destroy(bullet, 2.0f);
    }

    public void FireR()
    {
        // ÃÑ¾Ë ÇÁ¸®ÆÕ »ý¼º
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnR.position, bulletSpawnR.rotation);
        GameManager.instance.audioManager.Play(AudioManager.AudioType.Shoot, true);
        // ÃÑ¾Ë ¹ß»ç
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // 2ÃÊ µÚ¿¡ ÆÄ±«
        Destroy(bullet, 2.0f);
    }
}
