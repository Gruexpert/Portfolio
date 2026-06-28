using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 4f;
    public float sprint = 1.5f;
    public float knockbackForce = 10f;
    private bool isKnockedBack = false;


    private Vector2 movement;

    Vector2 direction = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Vector2.zero;
    
        if (Keyboard.current.wKey.isPressed)
            direction += Vector2.up;
    
        if (Keyboard.current.sKey.isPressed)
            direction += Vector2.down;
    
        if (Keyboard.current.aKey.isPressed)
            direction += Vector2.left;
    
        if (Keyboard.current.dKey.isPressed)
            direction += Vector2.right;
    
        direction = direction.normalized;
    
        movement = direction;
    
        if (Keyboard.current.shiftKey.isPressed)
            movement *= sprint;
    }


    void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            rb.linearVelocity = movement * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //ENEMIGOS

        if (collision.CompareTag("Karab"))
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.linearVelocity = Vector2.zero;
            isKnockedBack = true;
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

            Invoke(nameof(StopKnockback), 0.2f);
        }

        //OFF MAP TELEPORT
        if (collision.CompareTag("Karab"))
        {
            
        }

        //Ladder
        if (collision.CompareTag("Ladder"))
        {
            speed *= 0.5f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            speed *= 2f;
        }
    }
    void StopKnockback()
    {
        isKnockedBack = false;
    }
}
