using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObjects weaponData;
    float currentCoolDown;

    // private E_LookState currentLookState;

    protected PlayerMovement pm;

    // [SerializeField] protected int spawnRadius;

    // public E_LookState CurrentLookState { get => currentLookState; set => currentLookState = value; }

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
        if (currentCoolDown <= 0f)
        { Attack(); }

    }

    protected virtual void Attack()
    {
        currentCoolDown = weaponData.CoolDownDur;

        // switch (CurrentLookState)
        // {
        //     case E_LookState.RIGHT:
        //         transform.position = new Vector2(1, 0) * spawnRadius;
        //         break;
        //     case E_LookState.LEFT:
        //         transform.position = new Vector2(-1, 0) * spawnRadius;
        //         break;
        //     case E_LookState.UP:
        //         transform.position = new Vector2(0, 1) * spawnRadius;
        //         break;
        //     case E_LookState.DOWN:
        //         transform.position = new Vector2(0, -1) * spawnRadius;
        //         break;
        // }
    }
}
