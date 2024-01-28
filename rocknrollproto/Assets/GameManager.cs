using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bombCount = 3;

    public AudioSource audioSource;
    //public AudioClip selectedSong;
    public List<AudioClip> songList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarGame()
    {
        //play random song
        int randomIndex = Random.Range(0, songList.Count); // Generate a random index
        AudioClip randomElement = songList[randomIndex]; // Retrieve the element at the random index
        Debug.Log(randomElement.name);
        audioSource.PlayOneShot(randomElement);

        Debug.Log("Game Started");
    }
}
