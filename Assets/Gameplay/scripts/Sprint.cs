using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sprint : MonoBehaviour
{
    public bool isMoving = false;
    private float moveSpeed = 15.0f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void SprintAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMoving = true;
        }
        if (context.canceled)
        {
            isMoving = false;
        }
        if (Keyboard.current.leftShiftKey.isPressed && isMoving)
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}
