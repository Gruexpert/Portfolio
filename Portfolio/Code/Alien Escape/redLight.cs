using UnityEngine;

public class RedLight : MonoBehaviour
{
    public float timer = 1.5f;
    private bool isAtPositionA = true;

    bool GG = false;

    

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            isAtPositionA = !isAtPositionA;

            timer = 1.5f;
        }
        if(GG == false)
        {
            if(isAtPositionA)
            {
                transform.position = new Vector3(-30, 24, 0);
            }
            else
            {
                transform.position = new Vector3(30, 24, 0);
            }
        }
        else
        {
            transform.position = new Vector3(-100, 24, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GG = true;
        }
    }
}
