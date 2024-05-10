using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MediumBatsFactory))]
public class MediumEnemySpawner : MonoBehaviour, ISpawner
{
    private MediumBatsFactory mediumBatsFactory;

    private void Awake()
    {
        mediumBatsFactory = GetComponent<MediumBatsFactory>();
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
                var enemy = mediumBatsFactory.CreateMediumEnemies();
                enemy.transform.position = RandomPositionAroundSpawnPoint();
            }

            yield return new WaitForSeconds(3f);
        }
    }
}