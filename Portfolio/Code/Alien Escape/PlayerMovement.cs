using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement")]
    [SerializeField]
    private float speed =3f;    
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D pl;

    bool isTouchingGround = true;

    [SerializeField]
    float x;
    [SerializeField]
    float y;
    [SerializeField]
    float z;

    [SerializeField]
    float x2;
    [SerializeField]
    float y2;
    [SerializeField]
    float z2;

    [SerializeField]
    float x3;
    [SerializeField]
    float y3;
    [SerializeField]
    float z3;

    [SerializeField]
    float x4;
    [SerializeField]
    float y4;
    [SerializeField]
    float z4;

    [SerializeField]
    float xtp1;
    [SerializeField]
    float ytp1;
    [SerializeField]
    float ztp1;

    [SerializeField]
    float xtp2;
    [SerializeField]
    float ytp2;
    [SerializeField]
    float ztp2;

    public AudioSource jump;
    public AudioSource hurt;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pl = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
        }
        
        
        if (Keyboard.current.spaceKey.isPressed && isTouchingGround)
        {
            pl.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (Keyboard.current.spaceKey.isPressed && !jump.isPlaying)
            {
                jump.Play();
            }
            isTouchingGround = false;
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
        if (collision.gameObject.CompareTag("potion"))
        {
            transform.position = new Vector3(x2,y2,z2);
            hurt.Play();
        }
        if (collision.gameObject.CompareTag("pdi"))
        {
            transform.position = new Vector3(x,y,z);
            hurt.Play();
        }
        if (collision.gameObject.CompareTag("pdi2"))
        {
            transform.position = new Vector3(x4,y4,z4);
            hurt.Play();
        }
        if (collision.gameObject.CompareTag("tp1"))
        {
            transform.position = new Vector3(xtp1,ytp1,ztp1);
        }
        if (collision.gameObject.CompareTag("tp2"))
        {
            transform.position = new Vector3(xtp2,ytp2,ztp2);
        }
        if (collision.gameObject.CompareTag("ventpotion"))
        {
            transform.position = new Vector3(x3,y3,z3);
            hurt.Play();
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
