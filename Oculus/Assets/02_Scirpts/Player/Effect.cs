using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public GameObject healEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealEffect()
    {
        healEffect.SetActive(true);
        Invoke("HideHealEffect", 1f);
    }

    private void HideHealEffect()
    {
        healEffect.SetActive(false);
    }
}
