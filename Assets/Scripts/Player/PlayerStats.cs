using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

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

    void Awake()
    {
        //Assing the variables
        currentHealth = characterData.MaxHealth;
        currentsRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    public void IncreaseExperience(int amout) 
    {
        experience += amout;
        LevelUpChecher();
    }

    void LevelUpChecher()
    {
        if(experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
            int experiencCapIncrease = 0;
            foreach(LevelRange range in levelRanges) 
            {
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    experiencCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }

            experienceCap += experiencCapIncrease;
        }
    
    }

}
