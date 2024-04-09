using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody theRB;
    private float moveSpeed = 15.0f;
    private float maxSpeed = 30.0f;
    private float jumpForce = 7.0f;
    private float horizontalInput;
    private float verticalInput;

    public bool grounded;
    public bool isMoving = false;

    public int maxJumpCount = 2;
    public int jumpsRemaining = 0;

    private void Start()
    {
        theRB = GetComponent<Rigidbody>();
        theRB.freezeRotation = true;
    }

    void Update()
    {
        float currentSpeed = isMoving ? maxSpeed : moveSpeed;
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized * currentSpeed;
        theRB.velocity = new Vector3(horizontalInput * moveSpeed, theRB.velocity.y, verticalInput * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
        verticalInput = context.ReadValue<Vector2>().y;
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            
            isMoving = true;
            moveSpeed++;
            if(moveSpeed == maxSpeed)
            {
                Debug.Log("Osi¹gniêto maksymaln¹ prêdkoœæ!");
            }
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            isMoving = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if ((context.performed) && (jumpsRemaining > 0))
        {
            theRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsRemaining -= 1;
        }
    }

    public void OnCollisionEnter(Collision collision) // if player hit the floor
    {
        if(collision.gameObject.tag == "Floor")
        {
            grounded = true;
            jumpsRemaining = maxJumpCount;
        }
    }

    public void OnCollisionExit(Collision collision) // if player touch the floor
    {
        if (collision.gameObject.tag == "Floor")
        {
            grounded = false;
        }
    }
}