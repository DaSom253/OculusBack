using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Player player;

    public Image hpBar;
    private float maxHp;


    private void Update()
    {

        if(player.hp != 0)
        {
            hpBar.fillAmount = player.hp / player.maxHp;
        }
        
    }
}
