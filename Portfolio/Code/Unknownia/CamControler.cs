using UnityEngine;

public class CamControler : MonoBehaviour
{
    
    public Transform player;
    public float smoothSpeed;

    private Vector3 TargetPos, NewPos;

    public Vector3 MinPos, MaxPos;


    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            TargetPos = player.position;

            Vector3 camBoundryPos = new Vector3(
                Mathf.Clamp(TargetPos.x, MinPos.x, MaxPos.x),
                Mathf.Clamp(TargetPos.y, MinPos.y, MaxPos.y),
                Mathf.Clamp(TargetPos.z, MinPos.z, MaxPos.z)
                );
            
            NewPos = Vector3.Lerp(transform.position,camBoundryPos,smoothSpeed);
            transform.position = NewPos;
        }
    }
}
