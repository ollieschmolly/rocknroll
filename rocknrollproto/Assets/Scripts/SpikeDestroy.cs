using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDestroy : MonoBehaviour
{
    public GameObject youdiepanel;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the player object
            Destroy(other.gameObject);

            // Optionally, you can add game over logic here
            // For example, reloading the scene or showing a game over screen
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // UIManager.instance.ShowGameOverScreen();
        }
    }
}
