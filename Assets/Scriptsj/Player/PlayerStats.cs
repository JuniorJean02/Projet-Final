using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    private static PlayerStats instance = null;
    public static PlayerStats Instance { get => (instance == null) ? instance = FindObjectOfType<PlayerStats>() : instance; }
    public CharacterScriptableObject CharacterData { get => characterData; set => characterData = value; }

    public static event Action OnPlayerDeath;

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

    public void IncreaseExperience(int amout)
    {
        experience += amout;
        LevelUpChecher();
    }

    void LevelUpChecher()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
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
        Debug.Log(Health - damagePoints);
        Debug.Log(CurrentHealth - damagePoints);

        if (!playerIsDead)
            Health -= damagePoints;
        // CurrentHealth -= damagePoints;
    }

    public void OnDeath()
    {
        throw new System.NotImplementedException();
    }
}
