using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController2D : MonoBehaviour
{
    public float explosionForce = 10f;
    public float explosionRadius = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Explode(collision.GetComponent<Rigidbody2D>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Explode(null);
        }
    }

    private void Explode(Rigidbody2D rb)
    {
        if (rb != null)
        {
            Vector2 explosionDirection = (rb.transform.position - transform.position).normalized;

            float distance = Vector2.Distance(rb.transform.position, transform.position);
            float explosionForceAtDistance = CalculateExplosionForce(distance);

            // Apply force based on mass and distance
            rb.AddForce(explosionDirection * explosionForceAtDistance, ForceMode2D.Impulse);
        }

        // Optionally, you can instantiate particle effects, play sound, or destroy the bomb object here
        Destroy(gameObject);
    }

    private float CalculateExplosionForce(float distance)
    {
        // Adjust these parameters based on your desired explosion behavior
        float maxDistance = explosionRadius;
        float normalizedDistance = Mathf.Clamp01(1 - (distance / maxDistance));

        // Calculate explosion force based on normalized distance
        return explosionForce * normalizedDistance;
    }
}
