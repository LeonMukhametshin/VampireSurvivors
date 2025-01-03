using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStats enemy;
    private Transform player;

    private void Awake()
    {
        enemy = GetComponent<EnemyStats>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemy.currentMoveSpeed * Time.deltaTime);
    }
}
