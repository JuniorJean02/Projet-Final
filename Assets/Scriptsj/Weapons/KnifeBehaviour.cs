using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KnifeBehaviour : ProjectileWeapons
{
    [SerializeField] private Collider2D weaponCollider2D;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * weaponData.Speed * direction;
    }

    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     Debug.Log($"Trigger Enter {collider.CompareTag("Enemy")}, Hit Target {collider.gameObject.name}");
    //     if (collider == null) return;

    //     // if ()

    //     if (collider.CompareTag("Enemy"))
    //     {
    //         Debug.Log($"Enemy Hit Trigger By Weapon: {collider.gameObject.name}");
    //         collider.GetComponent<EnemyStats>().OnEnemyHitEvent.Invoke(transform.gameObject);
    //         collider.GetComponent<EnemyStats>().OnEnemyHit(weaponData.Damage, transform.gameObject);
    //         // if (_ = collider.GetComponent<EnemyStats>())
    //         // {
    //         // }
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D collider = other.collider;

        if (collider == null) return;

        if (collider.TryGetComponent<IDamageable>(out var damageable))
        {
            if (damageable != null)
            {
                if (collider.CompareTag("Enemy"))
                {
                    (damageable as EnemyStats).OnHit(weaponData.Damage);
                }
            }
        }
    }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log($"Trigger Enter {collision.collider.CompareTag("Enemy")}, Hit Target {collision.collider.gameObject.name}");
    //     if (collision == null) return;

    //     // if ()

    //     if (collision.collider.CompareTag("Enemy"))
    //     {
    //         Debug.Log($"Enemy Hit Trigger By Weapon: {collision.collider.gameObject.name}");
    //         collision.collider.GetComponent<EnemyStats>().OnEnemyHitEvent.Invoke(transform.gameObject);
    //         collision.collider.GetComponent<EnemyStats>().OnEnemyHit(weaponData.Damage, transform.gameObject);
    //         // if (_ = collider.GetComponent<EnemyStats>())
    //         // {
    //         // }
    //     }
    // }
}
