using UnityEngine;

public class RandomEnemy : MonoBehaviour
{
    public float speed = 3f;

    public float moveTime = 2f;   // how long it moves
    public float waitTime = 1f;   // how long it stays still

    private Rigidbody2D rb;
    private Vector2 moveDir;

    private float timer;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartMoving();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isMoving && timer >= moveTime)
        {
            StopMoving();
        }
        else if (!isMoving && timer >= waitTime)
        {
            StartMoving();
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
            rb.linearVelocity = moveDir * speed;
        else
            rb.linearVelocity = Vector2.zero;
    }

    void StartMoving()
    {
        PickNewDirection();
        isMoving = true;
        timer = 0f;
    }

    void StopMoving()
    {
        isMoving = false;
        timer = 0f;
    }

    void PickNewDirection()
    {
        Vector2[] directions =
        {
            Vector2.right,
            Vector2.left,
            Vector2.up,
            Vector2.down
        };

        moveDir = directions[Random.Range(0, directions.Length)];
    }
}
