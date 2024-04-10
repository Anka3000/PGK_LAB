using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Rigidbody theRB;
    private float moveSpeed = 15.0f;
    private float jumpForce = 7.0f;
    private float horizontalInput;
    private float verticalInput;
    public bool grounded;
    public int maxJumpCount = 2;
    public int jumpsRemaining = 0;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30.0f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private void Start()
    {
        theRB = GetComponent<Rigidbody>();
        theRB.freezeRotation = true;
    }

    void Update()
    {
        /*Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement.Normalize();

        if (movement != Vector3.zero)
        {
            Vector3 forwardDirection = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(forwardDirection, Vector3.up);
            transform.rotation = targetRotation;
        }*/

        theRB.velocity = new Vector3(horizontalInput * moveSpeed, theRB.velocity.y, verticalInput * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
        verticalInput = context.ReadValue<Vector2>().y;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
            if ((context.performed) && (jumpsRemaining > 0))
            {
                theRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpsRemaining -= 1;
            }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if ((context.performed) && canDash)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        canDash = false;
        isDashing = true;
        theRB.useGravity = false;
        float originalSpeed = moveSpeed;
        moveSpeed = dashingPower;
        yield return new WaitForSeconds(dashingTime);
        theRB.useGravity = true;
        moveSpeed = originalSpeed;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void OnCollisionEnter(Collision collision) // if player hit the floor
    {
        if (collision.gameObject.tag == "Floor")
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
