using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HardBatsFactory))]
public class HardEnemySpawner : MonoBehaviour, ISpawner
{
    private HardBatsFactory hardBatsFactory;

    private void Awake()
    {
        hardBatsFactory = GetComponent<HardBatsFactory>();
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
                var enemy = hardBatsFactory.CreateHardEnemies();
                enemy.transform.position = RandomPositionAroundSpawnPoint();
            }

            yield return new WaitForSeconds(3f);
        }
    }
}