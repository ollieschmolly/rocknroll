using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip selectedSong;
    public List<AudioClip> explosionSoundList;
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, explosionSoundList.Count); // Generate a random index
        AudioClip randomElement = explosionSoundList[randomIndex]; // Retrieve the element at the random index
        Debug.Log(randomElement.name);
        audioSource.PlayOneShot(randomElement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
