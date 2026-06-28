using UnityEngine;
using UnityEngine.UIElements;

public class potion1 : MonoBehaviour
{
    [Header("Rotation Speed")]
    [SerializeField]
    float rotationSpeed = 100f;
    
    void Update()
    {
        transform.Rotate(Vector3.forward*rotationSpeed* Time.deltaTime);  
    }
}
