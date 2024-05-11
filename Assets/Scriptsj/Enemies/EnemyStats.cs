using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemiesScriptableObjects enemyData;
    public EnemiesScriptableObjects EnemyData { get => enemyData; set => enemyData = value; }
    private float currentHealth;

    public UnityEvent OnEnemyDeathEvent;
    public UnityEvent<GameObject> OnEnemyHitEvent;
    [SerializeField] private bool isDead;

    private AudioSource audioSource;

    public float Health
    {
        set
        {
            if (Health <= 0)
            {
                OnEnemyDeathEvent?.Invoke();
                isDead = true;

                Debug.Log("Enemy is DEAD");
            }
        }

        get
        {
            return currentHealth;
        }
    }

    private void Awake()
    {
        currentHealth = enemyData.MaxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    //TODO: finish the OnHit event for the enemy (so that it receives damage from the players weapons)// 
    public void OnHit(float damagePoints)
    {
        Debug.Log("EnemyHealth");
        Debug.Log("BITCH SHIT");

        Health -= damagePoints;
    }

    public void OnEnemyHit(float damagePoints, GameObject attackSender)
    {
        Debug.Log($"TEST - Enemy {attackSender.name}");
        if (isDead) return;

        Health -= damagePoints;
        OnEnemyHitEvent?.Invoke(attackSender);

        // if ()
    }

    public void TEST()
    {
        Debug.Log("BITCH SHIT");
    }

    public void OnDeath()
    {
        audioSource.PlayOneShot(enemyData.DeathSFX);
        this.gameObject.SetActive(false);
        GameObject itemDropInstance = Instantiate(enemyData.ItemDrop, transform.parent);
        itemDropInstance.transform.SetParent(null);
    }


    // private static EnemyStats instance;

    // public static EnemyStats Instance { get => (instance == null) ? instance = FindObjectOfType<EnemyStats>() : instance; }


    // private IEnumerator AttackPlayerCoroutine(IDamageable damageable)
    // {
    //     yield return new WaitForSeconds(50f);
    //     Debug.Log(damageable.ToString());
    //     Debug.Log("Health Before Hit: " + PlayerStats.Instance.Health + " HP");
    //     Debug.Log("PlayerHealth Before Hit: " + PlayerStats.Instance.CurrentHealth + " HP");
    //     damageable.OnHit(enemyData.Damage);
    //     Debug.Log("Health After Hit: " + PlayerStats.Instance.Health + " HP");
    //     Debug.Log("PlayerHealth After Hit: " + PlayerStats.Instance.CurrentHealth + " HP");
    // }

    // private void OnCollisionStay2D(Collider2D other)
    // {
    //     if (other.TryGetComponent<IDamageable>(out var damageable))
    //     {
    //         if (damageable != null)
    //             if (other.CompareTag("Player"))
    //             {
    //                 Debug.Log(damageable.ToString());
    //                 Debug.Log("PlayerHealth Before Hit: " + PlayerStats.Instance.Health + " HP");
    //                 damageable.OnHit(100);
    //                 Debug.Log("PlayerHealth After Hit: " + PlayerStats.Instance.Health + " HP");
    //             }
    //     }
    // }
}