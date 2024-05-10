using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;


[CreateAssetMenu(fileName = "weaponsScriptablesObject", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObjects : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    //Base stats for weapons 
    [SerializeField]
    float damage;
    public float Damage { get=> damage; private set => damage = value; }

    [SerializeField]
    float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField]
    float coolDownDur;
    public float CoolDownDur { get => coolDownDur; private set => coolDownDur = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }

}
