using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    private MapController mapController;

    public GameObject targetMap;

    private void Awake()
    {
        mapController = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapController.currentChunk = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && mapController.currentChunk == targetMap)
        {
            mapController.currentChunk = null;
        }
    }
}