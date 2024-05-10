using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesScriptablesObject", menuName = "ScriptableObject/Enemy")]

public class EnemiesScriptableObjects : ScriptableObject
{
    [SerializeField] float maxHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] float damage;

    [SerializeField] GameObject itemDrop;

    [SerializeField] AudioClip deathSFX;

    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float Damage { get => damage; private set => damage = value; }
    public GameObject ItemDrop { get => itemDrop; set => itemDrop = value; }
    public AudioClip DeathSFX { get => deathSFX; set => deathSFX = value; }
}
