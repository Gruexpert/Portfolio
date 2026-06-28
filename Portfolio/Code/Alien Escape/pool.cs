using UnityEngine;

public class pool : MonoBehaviour
{

private Rigidbody2D pl;
    public float speed =3f;  

    void Start()
    {
        pl = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("poolTeleport"))
        {
            speed = speed*-1;
        }
    }
}
