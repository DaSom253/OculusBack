using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using AESWithJava.Con;

public class PlayerData
{
    public int coin; //코인
    public int hpUp; //기본 체력 증가
    public int hpTimeHeal; //시간마다 체력 회복
    public int damageUp; //공격력 증가
    public int moveSpeedUp; //이동속도 증가
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance; // 싱글톤패턴

    public PlayerData playerData = new PlayerData(); // 플레이어 데이터 생성

    public string path; // 경로
    public static int SS; //

    private string key = "asdf";

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Path.Combine(Application.persistentDataPath, "save");	// 경로 지정
        print(path);
    }

    private void Update()
    {
    }

    public void SaveData()
    {
        Debug.Log("데이터 저장");
        string data = JsonUtility.ToJson(playerData);
        string encryptedData = AESWithJava.Con.Program.Encrypt(data, key); // 데이터를 암호화
        File.WriteAllText(path + SS.ToString() + ".Json", encryptedData);
    }

    public void LoadData()
    {
        Debug.Log("데이터로드");
        try
        {
            string data = File.ReadAllText(path + SS.ToString() + ".Json");
            string decryptedData = AESWithJava.Con.Program.Decrypt(data, key); // 데이터를 복호화
            playerData = JsonUtility.FromJson<PlayerData>(decryptedData);
        }
        catch (FileNotFoundException)
        {
            Debug.LogWarning($"파일 찾을 수 없음 : {path + SS.ToString() + ".Json"}");
        }
        catch (IOException ex)
        {
            Debug.LogError($"파일 읽기 불가능 : {path + SS.ToString() + ".Json"}\n{ex}");
        }
    }

    void DataSet()
    {
        GameManager.instance.coin = playerData.coin;
    }


    public void DelData()
    {
        if(File.Exists(path + $"{SS}" + ".Json"))
        {
            File.Delete(path + $"{SS}" + ".Json");
        }
        else
        {
            Debug.Log("세이브 파일이 없습니다.");
        }
    }

    public void DataClear()
    {
        SS = -1;
        playerData = new PlayerData();
    }

}
