using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10.0f;

    void Update()
    {

    }

    public void Fire(InputAction.CallbackContext context)
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

        Bullet bulletScript = GetComponentInChildren<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.ChildMethod();
        }
        else
        {
            Debug.LogWarning("Bullet component not found on any child object!");
        }
    }
}