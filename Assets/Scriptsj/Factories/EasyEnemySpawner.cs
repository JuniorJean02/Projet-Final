using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EasyBatsFactory))]
public class EasyEnemySpawner : MonoBehaviour
{
    private EasyBatsFactory easyBatsFactory;

    private void Awake()
    {
        easyBatsFactory = GetComponent<EasyBatsFactory>();
    }

    private void Start()
    {
        StartCoroutine(SpawnerCoroutine());
    }

    public Vector2 RandomPositionAroundSpawnPoint() => (Vector2)this.transform.position + (Random.insideUnitCircle * 10f);

    public IEnumerator SpawnerCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < 4; i++)
            {
                var enemy = easyBatsFactory.CreateEasyEnemies();
                enemy.transform.position = RandomPositionAroundSpawnPoint();
            }

            yield return new WaitForSeconds(3f);
        }
    }
}