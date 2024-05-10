using System.Collections;
using UnityEngine;

public interface ISpawner
{
    Vector2 RandomPositionAroundSpawnPoint();
    IEnumerator SpawnerCoroutine();
}