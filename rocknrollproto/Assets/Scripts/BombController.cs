using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float explosionForce = 10f;
    public float explosionRadius = 5f;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player")) // Adjust the tag based on your character
        {
            Debug.Log("Player hit by bomb!");
            Explode();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            if (hit.CompareTag("Player")) // Adjust the tag based on your character
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }
        }

        // Optionally, you can instantiate particle effects, play sound, or destroy the bomb object here
        print("explode");
        Destroy(gameObject);
    }
}
