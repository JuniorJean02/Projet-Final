using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBatsFactory : MonoBehaviour
{
    public static HardBatsFactory Instance { get; private set; }

    int HardBatsIndex;

    [SerializeField] GameObject redBat;

    [SerializeField] List<GameObject> pooledHardBatsEnemies;

    private void Awake()
    {
        Instance = this;

        PopulateHardBatsPool();
    }

    private void PopulateHardBatsPool()
    {
        pooledHardBatsEnemies = new List<GameObject>();

        for (int i = 0; i < 50 / 4; i++)
        {
            pooledHardBatsEnemies.Add(Clone(redBat));
        }
    }

    public GameObject CreateHardEnemies()
    {
        pooledHardBatsEnemies[HardBatsIndex++ % pooledHardBatsEnemies.Count].SetActive(true);

        return pooledHardBatsEnemies[HardBatsIndex];
    }

    public GameObject Clone(GameObject objToClone)
    {
        objToClone.SetActive(false);
        return Instantiate(objToClone, this.transform);
    }
}
