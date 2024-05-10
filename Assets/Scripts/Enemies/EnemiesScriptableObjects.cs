using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesScriptablesObject", menuName = "ScriptableObject/Enemy")]

public class EnemiesScriptableObjects : ScriptableObject
{
    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float maxiHealth;
    public float MaxiHealth { get => maxiHealth; private set => maxiHealth= value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }
}
