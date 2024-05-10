using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawendGarlic = Instantiate(weaponData.Prefab);
        spawendGarlic.transform.position = transform.position;
        spawendGarlic.transform.parent = transform; 

    }
}
