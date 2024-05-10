using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "ScriptableObject/CharacterStats")]
public class CharacterScriptableObject : ScriptableObject
{

    [SerializeField]
    GameObject startingWeapon;
    public GameObject  StartingWeapon{ get => startingWeapon; set => startingWeapon = value; }
    [SerializeField] 
    float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    [SerializeField] 
    int exp;
    public int Exp { get => exp; set => exp = value; }
    [SerializeField] 
    int level;
    public int Level { get => level; set => level = value; }
    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; set => recovery = value; }

    [SerializeField]
    float might;
    public float Might { get => might; set => might = value; }

    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
}
