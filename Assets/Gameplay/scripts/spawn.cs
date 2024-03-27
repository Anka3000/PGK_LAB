using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float spawnTime = 5;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float spawnDelay = 2;
    private List<GameObject> spawnedObjects = new List<GameObject>();

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
        GameObject newCube = Instantiate(cubePrefab, transform.position, transform.rotation);
        newCube.transform.parent = transform;
        spawnedObjects.Add(newCube);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= spawnTime;
    }
}
