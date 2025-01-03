using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private PlayerStats player;
    private CircleCollider2D playerCollector;
    public float pullSpeed;

    private void Start()
    {
        player = GetComponentInParent<PlayerStats>();
        playerCollector = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        playerCollector.radius = player.currentMagnet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollectible collectible))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 foreceDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(foreceDirection * pullSpeed);

            collectible.Collect();
        }
    }
}