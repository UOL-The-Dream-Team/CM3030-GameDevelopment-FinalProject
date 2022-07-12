using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ABPlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float TurnSpeed;

    [SerializeField]
    public float MoveSpeed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    private Vector3 movementVec;

    private new Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //isOnFloor = Physics.Raycast(transform.position + Vector3.up, Vector3.down, 1f);

        //if (isOnFloor)
        //{
        //rb.AddForce(transform.forward * movementVec.z * MoveSpeed);
        rb.MovePosition(transform.position + transform.forward * movementVec.z * MoveSpeed * Time.fixedDeltaTime);

        Vector3 rotation = Vector3.up * movementVec.x * TurnSpeed;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);

       
        //rb.AddTorque(transform.up * movementVec.x * TurnSpeed);
        //}

    }

    public void OnMove(InputValue input)
    {
        Vector2 xyInput = input.Get<Vector2>();

        movementVec = new Vector3(xyInput.x, 0, xyInput.y);
    }

    //public void OnFire()
    //{
        //fireBullet.Fire();
    //}
}
