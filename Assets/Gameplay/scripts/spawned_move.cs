using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Poruszanie si� obiektu wzd�u� osi X
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
