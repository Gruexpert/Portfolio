using UnityEngine;

public class BasicEnemies : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed = 0.5f;
    private Vector2 direction = Vector2.left;

    [SerializeField]
    float x;
    [SerializeField]
    float y;
    [SerializeField]
    float z;

    bool isTouchingwall = false;



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            direction = -direction;
            transform.eulerAngles = direction.x > 0? new Vector3(0, 180f, 0): Vector3.zero;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchingwall = true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.angularVelocity = 0f;
            transform.rotation = Quaternion.identity;
            if (isTouchingwall == true)
            {
                transform.position = new Vector3(x,y,z);
            }
        }
        
        if (collision.gameObject.CompareTag("ventpotion"))
        {
            transform.position = new Vector3(x,y,z);
        }
    }

    void Update()
    {
        transform.Translate(direction*speed*Time.deltaTime, Space.World);        
    }
}