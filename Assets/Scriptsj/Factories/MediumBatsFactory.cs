using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBatsFactory : MonoBehaviour
{
    public static MediumBatsFactory Instance { get; private set; }

    int MediumBatsIndex;

    [SerializeField] GameObject yellowBat;

    [SerializeField] List<GameObject> pooledMediumBatsEnemies;

    private void Awake()
    {
        Instance = this;

        PopulateMediumBatsPool();
    }

    private void PopulateMediumBatsPool()
    {
        pooledMediumBatsEnemies = new List<GameObject>();

        for (int i = 0; i < 50 / 4; i++)
        {
            pooledMediumBatsEnemies.Add(Clone(yellowBat));
        }
    }

    public GameObject CreateMediumEnemies()
    {
        pooledMediumBatsEnemies[MediumBatsIndex++ % pooledMediumBatsEnemies.Count].SetActive(true);

        return pooledMediumBatsEnemies[MediumBatsIndex];
    }

    public GameObject Clone(GameObject objToClone)
    {
        objToClone.SetActive(false);
        return Instantiate(objToClone, this.transform);
    }
}
