using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public AudioManager audioManager;
    public static GameManager instance;

    public int coin;
    public Text coin_Text;

    public bool SS = false;

    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null && SS)
        {
            StartCoroutine(FindPlayer());
            if(player != null && !player.gameObject.activeSelf)
            {
                SS = false;
            }
        }
        if(coin_Text != null)
        {
            coin_Text.text = coin.ToString();
        }

        if(player.hp <= 0 && SS)
        {
            StartCoroutine(GameOver());
        }

    }

    public void ApplyDamageToLastSpawnedEnemy(float damage)
    {
        SpawnEnemy spawnEnemy = FindObjectOfType<SpawnEnemy>();
        if (spawnEnemy != null)
        {
            spawnEnemy.ApplyDamageToLastSpawnedEnemy(damage);
        }
    }

    IEnumerator GameOver()
    {
            SS = false;
            Debug.Log("게임오버");
            DataManager.instance.playerData.coin += coin;
            DataManager.instance.SaveData();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Main");

    }

    IEnumerator FindPlayer()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
        }

        GameObject coin_textObj = GameObject.Find("CoinText");
        if (coin_textObj != null)
        {
            coin_Text = coin_textObj.GetComponent<Text>();
        }

        GameObject AudioObject = GameObject.Find("Audio");
        if (AudioObject != null)
        {
            audioManager = AudioObject.GetComponent<AudioManager>();
        }

        DataManager.instance.LoadData();
        yield return null;

    }
}
