using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject itemPrefab;



    // Start is called before the first frame update
    void Start()
    {       
        itemPrefab.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropItem(float x, float y, float z)
    {
        //itemPrefab의 위치 설정
        itemPrefab.SetActive(true);
    }
    
    //몬스터가 죽을 때마다(상태) 랜덤한 아이템 호출하여야함
}
