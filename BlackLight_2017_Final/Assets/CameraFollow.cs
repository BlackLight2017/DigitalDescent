using UnityEngine;
using XboxCtrlrInput;
public class CameraFollow : MonoBehaviour {
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset; 

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

      //  transform.LookAt(target); 

        if (XCI.GetAxis(XboxAxis.LeftStickX) < 0 )
        {
            offset.x = -5;
        }
        if (XCI.GetAxis(XboxAxis.LeftStickX) > 0)
        {
            offset.x = 5;
        }
    }

  

}
