using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;
    private Vector2 moveDirection;

    [HideInInspector] public float LastHorizontalVector { get; private set; }
    [HideInInspector] public float LastVerticalVector { get; private set; }
    [HideInInspector] public Vector2 MoveDirection { get { return moveDirection; } }

    [HideInInspector] public Vector2 LastMoveVector;

    public CharacterScriptableObject characterData;

    private void Awake()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        LastMoveVector = new Vector2(1, 0f);
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
            LastMoveVector = new Vector2(LastHorizontalVector, 0f);
        }
        if (moveDirection.y != 0)
        {
            LastVerticalVector = moveDirection.y;
            LastMoveVector = new Vector2(0f, LastVerticalVector);
        }

        if (moveDirection.x != 0 && moveDirection.y != 0)
        {
            LastMoveVector = new Vector2(LastHorizontalVector, LastVerticalVector);
        }
    }

    private void Move()
    {
        playerRigidbody2D.velocity = moveDirection * characterData.MoveSpeed;
    }
}
