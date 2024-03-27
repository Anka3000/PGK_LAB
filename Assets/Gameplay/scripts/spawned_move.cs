using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5.0f;
    private float angleInDegrees = 0.0f;

    void Update()
    {
        Vector3 direction = Quaternion.Euler(0, angleInDegrees, 0) * Vector3.forward;

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
