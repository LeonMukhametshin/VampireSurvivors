using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
    [SerializeField] private Transform map;
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

        Vector2Int[] directions = new Vector2Int[]
        {
        new Vector2Int(1, 0),  // Right
        new Vector2Int(-1, 0), // Left
        new Vector2Int(0, 1),  // Up
        new Vector2Int(0, -1), // Down
        new Vector2Int(1, 1),  // Right Up
        new Vector2Int(1, -1), // Right Down
        new Vector2Int(-1, 1), // Left Up
        new Vector2Int(-1, -1) // Left Down
        };

        foreach (var direction in directions)
        {
            // ѕолучаем позицию провер€емой точки
            string directionName = GetDirectionName(direction);
            Transform checkPoint = currentChunk.transform.Find(directionName);

            if (checkPoint != null)
            {
                Vector3 checkPosition = checkPoint.position;

                // ѕровер€ем наличие чанка в указанной точке
                if (!Physics2D.OverlapCircle(checkPosition, checkerRadius, terrainMask))
                {
                    noTerrainPosition = checkPosition;
                    SpawnChunk();
                }
            }
        }
    }

    private string GetDirectionName(Vector2Int direction)
    {
        if (direction == new Vector2Int(1, 0)) return "Right";
        if (direction == new Vector2Int(-1, 0)) return "Left";
        if (direction == new Vector2Int(0, 1)) return "Up";
        if (direction == new Vector2Int(0, -1)) return "Down";
        if (direction == new Vector2Int(1, 1)) return "Right Up";
        if (direction == new Vector2Int(1, -1)) return "Right Down";
        if (direction == new Vector2Int(-1, 1)) return "Left Up";
        if (direction == new Vector2Int(-1, -1)) return "Left Down";
        return string.Empty;
    }

    private void SpawnChunk()
    {
        int random = Random.Range(0, terrainChunks.Count);
        latestChunks = Instantiate(terrainChunks[random], noTerrainPosition, Quaternion.identity, map.transform);
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