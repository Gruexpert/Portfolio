using System.Diagnostics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject Alien1;

    void Update()
    {
        transform.position = new Vector3(Alien1.transform.position.x+1, Alien1.transform.position.y+1, Alien1.transform.position.z-10);
    }
}
