using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapons : MonoBehaviour
{
    public WeaponScriptableObjects weapondData;
    public float destrayAfterSeconds;
    protected virtual void Start()
    {

        Destroy(gameObject, destrayAfterSeconds);
        
    }

   
}
