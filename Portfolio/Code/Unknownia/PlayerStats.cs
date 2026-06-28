using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{   
    private Collider2D col;
    
    public float Life = 10f;

    public float ImunityFrames = 1f;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Life <= 0)
        {
            QuitGame();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Karab"))
        {
            Life -= 2;
        }

    }

    public void LevarDano()
    {
        StartCoroutine(Imunidade());
    }

    IEnumerator Imunidade()
    {
        col.enabled = false;
        yield return new WaitForSeconds(ImunityFrames);
        col.enabled = true;
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
