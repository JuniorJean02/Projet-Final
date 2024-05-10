using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
public class ItemDrop : MonoBehaviour
{
    [SerializeField] private EnemyItemDropsSO enemyItemDropsSO;

    public EnemyItemDropsSO EnemyItemDropsSO { get => enemyItemDropsSO; }

    public UnityEvent PickUpEvent;

    private SpriteRenderer EnemySpriteRenderer => this.GetComponent<SpriteRenderer>();

    private void Awake()
    {
        EnemySpriteRenderer.sprite = enemyItemDropsSO != null ? enemyItemDropsSO.ItemDropSprite : null;
    }

    public void AddPlayerExp()
    {
        Debug.Log("PlayerXP Before: " + PlayerStats.Instance.experience);
        PlayerStats.Instance.experience += enemyItemDropsSO.ItemDropTypePoints;
        Debug.Log("PlayerXP After: " + PlayerStats.Instance.experience);
    }

    public void DisablePickedUpItem()
    {
        this.gameObject.SetActive(false);
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Hero"))
    //     {
    //         this.gameObject.SetActive(false);
    //         PlayerStatsST.Instance.CurrentHeroExp += enemyItemDropsSO.ItemDropTypePoints;
    //         // EnemyItemDropsSO.ItemDropTypePoints = 10;
    //         Debug.Log("TEST");
    //     }
    // }

    // // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
