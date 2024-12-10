using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerMovement.MoveDirection.magnitude > 0)
        {
            animator.SetBool("Move", true);

            SpriteDirectinChecker();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void SpriteDirectinChecker()
    {
        if (playerMovement.LastHorizontalVector > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}