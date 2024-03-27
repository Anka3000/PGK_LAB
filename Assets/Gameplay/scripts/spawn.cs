using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float spawnTime = 5;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float spawnDelay = 2;

    private void Update()
    {
        if (ShouldSpawn())
        {
            DoSpawn(); 
        }
    }

    private void DoSpawn()
    {
        spawnTime = Time.time + spawnDelay; 
        Instantiate(cubePrefab, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= spawnTime;
    }
}
