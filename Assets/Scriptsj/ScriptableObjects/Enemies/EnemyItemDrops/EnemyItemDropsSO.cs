using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public enum E_EnemyDropTypes
{
    None = 0,
    ExperiencePoints = 1,
    Money = 2,
}

[CreateAssetMenu(fileName = "EnemyItemDrop_SO", menuName = "ScriptableObjects/EnemyItemDrop")]
public class EnemyItemDropsSO : ScriptableObject
{
    [SerializeField] private E_EnemyDropTypes enemyDropType = new();
    [SerializeField] private Sprite itemDropSprite;
    // [SerializeField] private GameObject[] enemyItemDrops;
    [SerializeField] private int itemDropTypePoints = 0;

    public EnemyItemDropsSO()
    {
        this.EnemyItemDropType = enemyDropType;
        // this.EnemyItemDrops = enemyItemDrops;
        this.ItemDropSprite = itemDropSprite;
        this.ItemDropTypePoints = itemDropTypePoints;
    }

    public E_EnemyDropTypes EnemyItemDropType { get => enemyDropType; set => enemyDropType = value; }
    // public GameObject[] EnemyItemDrops { get => enemyItemDrops; set => enemyItemDrops = value; }
    public Sprite ItemDropSprite { get => itemDropSprite; set => itemDropSprite = value; }
    public int ItemDropTypePoints { get => itemDropTypePoints; set => itemDropTypePoints = value; }
}
