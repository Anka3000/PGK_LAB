using UnityEngine;

public class particle_trigger : MonoBehaviour
{
    [SerializeField] private GameObject splashParticlePrefab;
    [SerializeField] private string waterTag = "Water"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(waterTag))
        {
            // pozycja kolizji
            Vector3 splashPosition = other.ClosestPoint(transform.position);

            Instantiate(splashParticlePrefab, splashPosition, Quaternion.identity);
        }
    }
}
