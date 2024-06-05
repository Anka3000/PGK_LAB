using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject splashParticlePrefab;
    [SerializeField] private string waterTag = "Water";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(waterTag))
        {
            // Pozycja kolizji - pierwszy punkt kontaktu
            Vector3 splashPosition = collision.contacts[0].point;

            Instantiate(splashParticlePrefab, splashPosition, Quaternion.identity);
        }
    }
}
