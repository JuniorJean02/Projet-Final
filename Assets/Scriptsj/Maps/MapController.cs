using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainePosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChuks;
    GameObject latestChuncks;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChekcker();
        ChunkOptimizer();
    }

    void ChunkChekcker()
    {
        if (!currentChunk)
        { return; }


        if (pm.moveDir.x > 0 && pm.moveDir.y == 0)//right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("right").position, checkerRadius, terrainMask))
            { noTerrainePosition = currentChunk.transform.Find("right").position; SpawnChuck(); }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)//left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left").position, checkerRadius, terrainMask))
            {
                noTerrainePosition = currentChunk.transform.Find("left").position;
                SpawnChuck();
            }
        }

        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0)//up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("up").position, checkerRadius, terrainMask))
            { noTerrainePosition = currentChunk.transform.Find("up").position; SpawnChuck(); }
        }

        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0)//down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            { noTerrainePosition = currentChunk.transform.Find("Down").position; SpawnChuck(); }
        }

        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)//rightup
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Rightup").position, checkerRadius, terrainMask))
            { noTerrainePosition = currentChunk.transform.Find("Rightup").position; SpawnChuck(); }
        }

        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)//rightdown
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightDown").position, checkerRadius, terrainMask))
            { noTerrainePosition = currentChunk.transform.Find("RightDown").position; SpawnChuck(); }
        }

        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)//leftup 
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("leftup").position, checkerRadius, terrainMask))
            { noTerrainePosition = currentChunk.transform.Find("leftup").position; SpawnChuck(); }
        }

        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)//leftdown
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("leftdown").position, checkerRadius, terrainMask))
            { noTerrainePosition = currentChunk.transform.Find("leftdown").position; SpawnChuck(); }
        }
    }

    void SpawnChuck()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainePosition, Quaternion.identity);
        spawnedChuks.Add(latestChuncks);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }

        else
        { return; }

        foreach (GameObject chunk in spawnedChuks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }

            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
