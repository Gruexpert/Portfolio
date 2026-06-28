using UnityEngine;

public class RIghtPotionMovement : MonoBehaviour
{
    [Header("Rotation Speed")]
    [SerializeField]
    float Speed = 5f;
    [SerializeField]
    float x;
    [SerializeField]
    float y;
    [SerializeField]
    float z;

    bool isTouchingwall = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*Speed*Time.deltaTime);



        isTouchingwall = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            isTouchingwall = true;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.angularVelocity = 0f;
            transform.rotation = Quaternion.identity;
            if (isTouchingwall == true)
        {
            transform.position = new Vector3(x,y,z);;
        }
        }
    }
}
