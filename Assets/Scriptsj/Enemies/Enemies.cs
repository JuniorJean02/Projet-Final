using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (!PlayerStats.Instance.PlayerIsDead)
            player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null || !PlayerStats.Instance.PlayerIsDead)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyStats.EnemyData.MoveSpeed * Time.deltaTime);
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log($"{other.gameObject.name}, {other.gameObject.tag}, {other.gameObject.CompareTag("Weapon")}");

    //     if (other.CompareTag("Weapon"))
    //     {
    //         Debug.Log($"Weapon Damage: {other.GetComponent<KnifeBehaviour>().weaponData.Damage}");
    //         // enemyStats.OnEnemyHitEvent.Invoke(other.gameObject);
    //         enemyStats.OnHit(other.GetComponent<KnifeBehaviour>().weaponData.Damage);

    //         // other.GetComponent<WeaponController>().weaponData.Damage;
    //     }
    // }

    private void OnCollisionStay2D(Collision2D otherCollision)
    {
        Collider2D collider = otherCollision.collider;

        if (collider.TryGetComponent<IDamageable>(out var damageable))
        {
            if (damageable != null)
            {
                // Debug.Log(damageable.ToString());
                // if (collider.CompareTag("Weapon"))
                //     enemyStats.OnHit(collider.GetComponent<ProjectileWeapons>().weaponData.Damage);

                if (collider.CompareTag("Player"))
                {
                    // Debug.Log("Health Before Hit: " + PlayerStats.Instance.Health + " HP");
                    // Debug.Log("PlayerHealth Before Hit: " + PlayerStats.Instance.CurrentHealth + " HP");
                    damageable.OnHit(enemyStats.EnemyData.Damage);
                    // Debug.Log("Health After Hit: " + PlayerStats.Instance.Health + " HP");
                    // Debug.Log("PlayerHealth After Hit: " + PlayerStats.Instance.CurrentHealth + " HP");

                    // StartCoroutine(AttackPlayerCoroutine(damageable));
                }
            }
        }
    }
}
