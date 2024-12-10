using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private List<Transform> propSpawnPoints;
    [SerializeField] private List<GameObject> propPrefabs;

    private void Start()
    {
        Debug.Log("Start Prop");
        SpawnProps();
    }

    private void SpawnProps()
    {
        Debug.Log("Start Spawn Prop");
        foreach (var spawnPoint in propSpawnPoints)
        {
            int random = Random.Range(0, propSpawnPoints.Count);
            GameObject prop = Instantiate(propPrefabs[random], spawnPoint.transform.position, Quaternion.identity);
            prop.transform.parent = spawnPoint.transform;
        }
        Debug.Log("Finish Prop spawn");
    }
}
