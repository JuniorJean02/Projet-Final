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
        HardBatsIndex %= pooledHardBatsEnemies.Count;
        GameObject hardEnemy = pooledHardBatsEnemies[HardBatsIndex++];
        // Debug.Log($"Medium Enemy {MediumBatsIndex}: [{mediumEnemy.transform.position}]");
        hardEnemy.SetActive(true);
        return hardEnemy;

        // Debug.Log(MediumBatsIndex);
        // // if (MediumBatsIndex >= 0)
        // Debug.Log($"Medium Enemy {MediumBatsIndex}: [{pooledMediumBatsEnemies[MediumBatsIndex].transform.position}]");
        // pooledMediumBatsEnemies[MediumBatsIndex++ % pooledMediumBatsEnemies.Count].SetActive(true);
        // return pooledMediumBatsEnemies[MediumBatsIndex];

        // return null;
    }

    public GameObject Clone(GameObject objToClone)
    {
        objToClone.SetActive(false);
        return Instantiate(objToClone, this.transform);
    }
}
