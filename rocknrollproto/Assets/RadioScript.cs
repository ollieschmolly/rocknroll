using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour
{
    // Define any variables needed for the pickup behavior
    public GameObject winpanel;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply the effect of the pickup (e.g., increase score, give power-up)
            // For example, increase the player's score by 100
            winpanel.SetActive(true);

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
