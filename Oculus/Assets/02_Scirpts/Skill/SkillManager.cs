using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill")]

public class SkillManager : ScriptableObject
{
    [SerializeField]
    private int damage_;
    public int damage { get { return damage_; } }

    [SerializeField]
    private float cooltime_;
    public float cooltime { get { return cooltime_; } }

    public GameObject skillPrefab;
}
