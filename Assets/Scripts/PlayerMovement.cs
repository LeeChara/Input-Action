using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerInputObserver
{
    [Header("# Movement Status")]
    private Vector2 currentDirection;
    public float moveSpeed = 1.0f;
    public float jumpForce = 1.0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(currentDirection.x * moveSpeed, rb.linearVelocity.y);
    }
    public void OnMove(Vector2 direction)
    {
        currentDirection = direction;
    }
    public void OnJump()
    {
        if(Mathf.Abs(rb.linearVelocity.y) < 0.1f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void OnAttack()
    {

    }
}
