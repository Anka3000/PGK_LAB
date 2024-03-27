
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
        public float life = 1;

        void Awake()
        {
            Destroy(gameObject, life);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player")) 
            {
                return; 
            }
         Destroy(collision.gameObject);
         Destroy(gameObject);

        }

    public void ChildMethod()
    {
        Debug.Log("Child method called!");
    }
}