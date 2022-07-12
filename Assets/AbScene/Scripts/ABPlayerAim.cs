using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ABPlayerAim : MonoBehaviour
{
    public GameObject head;
    Camera cam;
    Ray mouseRay;

    Vector3 hitPoint;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mouseRay = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hitInfo;

        if (Physics.Raycast(mouseRay, out hitInfo, 100f))
        {
            hitPoint = hitInfo.point;
        }

        Vector3 lookTarget = new Vector3(hitPoint.x, head.transform.position.y, hitPoint.z);
        head.transform.LookAt(lookTarget);
    }
}
