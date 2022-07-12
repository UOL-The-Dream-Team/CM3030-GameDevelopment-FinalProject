using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABCameraController : MonoBehaviour
{
    ///getting the transfor of the target
    public Transform target;

    //setting details of camera
    public Vector3 offset;
    public float smoothSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = transform.position = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);

    }
}
