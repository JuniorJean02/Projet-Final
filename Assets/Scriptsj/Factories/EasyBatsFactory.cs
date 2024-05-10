using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBatsFactory : MonoBehaviour
{
    public static EasyBatsFactory Instance { get; private set; }

    int EasyBatsIndex;

    [SerializeField] GameObject bat;

    [SerializeField] List<GameObject> pooledEasyBatsEnemies;

    private void Awake()
    {
        Instance = this;

        PopulateEasyBatsPool();
    }

    private void PopulateEasyBatsPool()
    {
        pooledEasyBatsEnemies = new List<GameObject>();

        for (int i = 0; i < 50 / 4; i++)
        {
            pooledEasyBatsEnemies.Add(Clone(bat));
        }
    }

    public GameObject CreateEasyEnemies()
    {
        pooledEasyBatsEnemies[EasyBatsIndex++ % pooledEasyBatsEnemies.Count].SetActive(true);

        return pooledEasyBatsEnemies[EasyBatsIndex];
    }

    public GameObject Clone(GameObject objToClone)
    {
        objToClone.SetActive(false);
        return Instantiate(objToClone, this.transform);
    }
}
