using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody theRB;
    private float moveSpeed = 15.0f;
    private float jumpForce = 7.0f;
    private float horizontalInput;
    private float verticalInput;

    private void Start()
    {
        theRB = GetComponent<Rigidbody>();
        theRB.freezeRotation = true;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement.Normalize();

        if (movement != Vector3.zero)
        {
            Vector3 forwardDirection = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
            transform.rotation = targetRotation;
        }

        if (Input.GetButtonDown("Jump"))
        {
            theRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        theRB.velocity = new Vector3(movement.x * moveSpeed, theRB.velocity.y, movement.z * moveSpeed);
    }
}
