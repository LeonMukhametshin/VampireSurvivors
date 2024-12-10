using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private List<GameObject> terrainChunks;
    [SerializeField] private GameObject player;
    [SerializeField] private float checkerRadius;

    private Vector2 noTerrainPosition;
    [SerializeField] private LayerMask terrainMask;

   // private PlayerMovement playerMovement;

    private void Awake()
    {
        // playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        ChunkChecker();
    }

    private void ChunkChecker()
    {
        //if (playerMovement)
        {

        }
    }
}
