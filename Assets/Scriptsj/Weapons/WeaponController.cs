using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObjects weaponData;
    float currentCoolDown;
    

    protected PlayerMovement pm;

    // Start is called before the first frame update
   protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();    
        currentCoolDown = weaponData.CoolDownDur;
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        currentCoolDown -= Time.deltaTime;
        if(currentCoolDown <=0f )
        { Attack(); }
        
    }

    protected virtual void Attack()
    {
        currentCoolDown = weaponData.CoolDownDur;
    }
}
