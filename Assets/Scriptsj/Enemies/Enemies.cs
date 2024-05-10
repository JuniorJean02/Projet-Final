using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyStats), typeof(AudioSource))]
public class Enemies : MonoBehaviour
{
    // public EnemiesScriptableObjects enemyData;
    Transform player;

    private EnemyStats enemyStats;

    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
    }

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyStats.EnemyData.MoveSpeed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D otherCollision)
    {
        Collider2D collider = otherCollision.collider;

        if (collider.TryGetComponent<IDamageable>(out var damageable))
        {
            if (damageable != null)
                if (collider.CompareTag("Player"))
                {
                    Debug.Log(damageable.ToString());
                    Debug.Log("Health Before Hit: " + PlayerStats.Instance.Health + " HP");
                    Debug.Log("PlayerHealth Before Hit: " + PlayerStats.Instance.CurrentHealth + " HP");
                    damageable.OnHit(enemyStats.EnemyData.Damage);
                    Debug.Log("Health After Hit: " + PlayerStats.Instance.Health + " HP");
                    Debug.Log("PlayerHealth After Hit: " + PlayerStats.Instance.CurrentHealth + " HP");

                    // StartCoroutine(AttackPlayerCoroutine(damageable));
                }
        }
    }
}
