using UnityEngine;

public class vat : MonoBehaviour
{

    public AudioSource plim;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(0,0,0);
            plim.Play();
        }
    }
}
