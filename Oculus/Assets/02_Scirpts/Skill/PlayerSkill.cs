using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    public GameObject player;
    public List<SkillManager> skillManager = new List<SkillManager>();
    public List<Image> skillIcon = new List<Image>();
    public List<Text> skillCount = new List<Text>();

    private float[] skillCool = { 0 };
    private bool isSkill = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player = GameObject.Find("OVRPlayerController");


        if (Input.GetKeyDown(KeyCode.Z))
        {
            OnSkill();
        }
    }

    public void OnSkill()
    {
        if (!isSkill)
        {
            StartCoroutine(SkillTimeCheck(0));
            GameManager.instance.audioManager.Play(AudioManager.AudioType.SnowAoe, true);
        }

    }



    IEnumerator SkillTimeCheck(int SkillNum)
    {

        isSkill = true;
        float cooldown = skillCool[SkillNum];
        SkillManager skill = skillManager[SkillNum];
        Text skillText = skillCount[SkillNum];

        cooldown = skill.cooltime;
        Vector3 spawnPosition = player.transform.position + new Vector3(0, -1, 0);
        Quaternion spawnRotation = Quaternion.identity;

        switch (SkillNum)
        {
            case 0:
                GameObject Skill_Z = Instantiate(skill.skillPrefab, spawnPosition, spawnRotation);
                Destroy(Skill_Z, 4.5f);
                break;
        }

        while (isSkill)
        {
            if (cooldown > 0)
            {
                skillIcon[SkillNum].fillAmount = cooldown / skill.cooltime;
                cooldown -= Time.deltaTime;
                skillText.gameObject.SetActive(true);
                skillText.text = ((int)cooldown).ToString();
            }
            else
            {
                skillText.gameObject.SetActive(false);
                isSkill = false;
            }
            yield return null;
        }

    }




}
