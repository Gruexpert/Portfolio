using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotation : MonoBehaviour
{
    [SerializeField] Sprite standartSprite;
    [SerializeField] Sprite walkSprite;
    [SerializeField] Sprite jumpSprite;
    [SerializeField] Sprite newSprite;

    bool isTouchingGround = false;
    private int lastDirection = 1;

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

        if(isTouchingGround == true)
        {
            if (Keyboard.current.aKey.isPressed && Keyboard.current.dKey.isPressed)
            {
                transform.eulerAngles = new Vector3(0, lastDirection == -1 ? -180f : 0, 0);
                newSprite = standartSprite;
            }
            else if (Keyboard.current.aKey.isPressed)
            {
                lastDirection = -1;
                transform.eulerAngles = new Vector3(0, -180f, 0);
                newSprite = walkSprite;
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                lastDirection = 1;
                transform.eulerAngles = new Vector3(0, 0, 0);
                newSprite = walkSprite;
            }
            else
            {
                newSprite = standartSprite;
            }
        }
        else if(isTouchingGround == false)
        {
            newSprite = jumpSprite;
            if (Keyboard.current.aKey.isPressed && Keyboard.current.dKey.isPressed)
            {
                transform.eulerAngles = new Vector3(0, lastDirection == -1 ? -180f : 0, 0);
            }
            else if (Keyboard.current.aKey.isPressed)
            {
                lastDirection = -1;
                transform.eulerAngles = new Vector3(0, -180f, 0);
            }
            else if (Keyboard.current.dKey.isPressed)
            {
                lastDirection = 1;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }
    }
}
