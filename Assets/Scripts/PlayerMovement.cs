using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D playerRigidbody2D;
    private Vector2 moveDirection;


    public float LastHorizontalVector { get; private set; }
    public float LastVerticalVector { get; private set; }   
    public Vector2 MoveDirection { get { return moveDirection; } }

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DirectionInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void DirectionInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float vertivalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontalInput, vertivalInput).normalized;

        if (moveDirection.x != 0)
        {
            LastHorizontalVector = moveDirection.x;
        }
        if (moveDirection.y != 0)
        {
            LastVerticalVector = moveDirection.y;   
        }
    }

    private void Move()
    {
        playerRigidbody2D.velocity = moveDirection * moveSpeed;
    }
}
