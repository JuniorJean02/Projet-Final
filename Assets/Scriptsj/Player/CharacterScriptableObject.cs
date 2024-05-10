using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats" + "_SO", menuName = "ScriptableObjects/CharacterStats")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] GameObject startingWeapon;
    [SerializeField] float maxHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] int exp;
    [SerializeField] int level;
    [SerializeField] float recovery;
    [SerializeField] float might;
    [SerializeField] float projectileSpeed;

    public GameObject StartingWeapon { get => startingWeapon; set => startingWeapon = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public int Exp { get => exp; set => exp = value; }
    public int Level { get => level; set => level = value; }
    public float Recovery { get => recovery; set => recovery = value; }
    public float Might { get => might; set => might = value; }
    public float ProjectileSpeed { get => projectileSpeed; set => projectileSpeed = value; }
}
