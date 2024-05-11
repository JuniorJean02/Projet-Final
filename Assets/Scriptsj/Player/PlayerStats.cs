using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour, IDamageable
{
    private static PlayerStats instance = null;
    public static PlayerStats Instance { get => (instance == null) ? instance = FindObjectOfType<PlayerStats>() : instance; }
    public CharacterScriptableObject CharacterData { get => characterData; set => characterData = value; }

    public UnityEvent OnPlayerDeath;

    public float Health
    {
        set
        {
            currentHealth = value;

            if (Health <= 0)
            {
                OnPlayerDeath?.Invoke();
                playerIsDead = true;

                Debug.Log("Player is DEAD");
            }
        }

        get
        {
            return currentHealth;
        }
    }

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public bool PlayerIsDead { get => playerIsDead; set => playerIsDead = value; }

    [SerializeField] private CharacterScriptableObject characterData;

    //Current stats
    float currentHealth;
    float currentsRecovery;
    float currentMoveSpeed;
    float currentMight;
    float currentProjectileSpeed;

    //experience and Level of the player
    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    public List<LevelRange> levelRanges;
    private bool playerIsDead = false;

    void Awake()
    {
        //Assing the variables
        currentHealth = CharacterData.MaxHealth;
        currentsRecovery = CharacterData.Recovery;
        currentMoveSpeed = CharacterData.MoveSpeed;
        currentMight = CharacterData.Might;
        currentProjectileSpeed = CharacterData.ProjectileSpeed;
    }

    void Start()
    {
        Debug.Log("Current PlayerHealth: " + CurrentHealth + " HP");

        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    // public void UpdatePlayerUI()
    // {
    //     UIManager.Instance.UpdateExperienceCount();
    // }

    // public void IncreaseExperience(int amout)
    // {
    //     Debug.Log("XP Points" + amout);
    //     experience += amout;
    //     LevelUpChecker();
    // }

    public void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience = 0;
            int experiencCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experiencCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }

            experienceCap += experiencCapIncrease;
        }

    }

    public void OnHit(float damagePoints)
    {
        // Debug.Log(Health - damagePoints);
        // Debug.Log(CurrentHealth - damagePoints);

        if (!playerIsDead)
            Health -= damagePoints;
        // CurrentHealth -= damagePoints;
    }

    public void OnDeath()
    {
        UIManager.Instance.GameOverPanelActive();
        this.gameObject.SetActive(false);
    }
}
