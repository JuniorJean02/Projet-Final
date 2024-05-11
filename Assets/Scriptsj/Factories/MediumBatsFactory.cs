using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBatsFactory : MonoBehaviour
{
    public static MediumBatsFactory Instance { get; private set; }

    [SerializeField] int MediumEnemyAmount;

    int MediumBatsIndex;

    [SerializeField] GameObject yellowBat;

    [SerializeField] List<GameObject> pooledMediumBatsEnemies;

    private void Awake()
    {
        PopulateMediumBatsPool();

        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    private void PopulateMediumBatsPool()
    {
        pooledMediumBatsEnemies = new List<GameObject>();

        for (int i = 0; i < MediumEnemyAmount; i++)
        {
            pooledMediumBatsEnemies.Add(Clone(yellowBat));
        }
    }

    public GameObject CreateMediumEnemies()
    {
        MediumBatsIndex %= pooledMediumBatsEnemies.Count;
        GameObject mediumEnemy = pooledMediumBatsEnemies[MediumBatsIndex++];
        // Debug.Log($"Medium Enemy {MediumBatsIndex}: [{mediumEnemy.transform.position}]");
        mediumEnemy.SetActive(true);
        return mediumEnemy;

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
