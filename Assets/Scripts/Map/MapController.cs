using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainChunks;
    [SerializeField] private GameObject player;
    [SerializeField] private float checkerRadius;

    [SerializeField] private LayerMask terrainMask;

    public GameObject currentChunk;
    private PlayerMovement playerMovement;
    private Vector2 noTerrainPosition;

    [Header("Optimization")]
    [SerializeField] private List<GameObject> spawnedChunks;
    [SerializeField] private GameObject latestChunks;
    [SerializeField] private float maxOptimizationDistance;
    private float optimizationCooldown;
    [SerializeField] private float optimizationCooldownDuration;

    private float optimizationDistance;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    private void ChunkChecker()
    {
        if (!currentChunk) return;

        if (playerMovement.MoveDirection.x > 0 && playerMovement.MoveDirection.y == 0) // right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.MoveDirection.x < 0 && playerMovement.MoveDirection.y == 0) // left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.MoveDirection.x == 0 && playerMovement.MoveDirection.y > 0) // up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.MoveDirection.x == 0 && playerMovement.MoveDirection.y < 0) // down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.MoveDirection.x > 0 && playerMovement.MoveDirection.y > 0) // right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.MoveDirection.x > 0 && playerMovement.MoveDirection.y < 0) // right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.MoveDirection.x < 0 && playerMovement.MoveDirection.y > 0) // left up 
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }
        else if (playerMovement.MoveDirection.x < 0 && playerMovement.MoveDirection.y < 0) // left down 
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        int random = Random.Range(0, terrainChunks.Count);
        latestChunks = Instantiate(terrainChunks[random], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunks);
    }

    private void ChunkOptimizer()
    {
        optimizationCooldown -= Time.deltaTime;
        if (optimizationCooldown <= 0f)
        {
            optimizationCooldown = optimizationCooldownDuration;
        }
        else
        {
            return;
        }

        foreach (var chunk in spawnedChunks)
        {
            optimizationDistance = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (optimizationDistance > maxOptimizationDistance)
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
