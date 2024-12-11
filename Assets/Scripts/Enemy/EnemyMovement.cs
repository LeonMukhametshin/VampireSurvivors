using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
