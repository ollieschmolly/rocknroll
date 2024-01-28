using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public GameObject bombPrefab;

    //audio variables
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public List<AudioClip> walkSounds;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Horizontal"))
        {
            //play random walk sound
            int randomIndex = Random.Range(0, walkSounds.Count); // Generate a random index
            AudioClip randomElement = walkSounds[randomIndex]; // Retrieve the element at the random index
            Debug.Log(randomElement.name);
            audioSource.PlayOneShot(randomElement);
        }   

        if(Input.GetButtonDown("Jump"))
        {
            //play jump sound
            audioSource.PlayOneShot(jumpSound);

            jump = true;
            animator.SetBool("IsJumping", true);
            Debug.Log("Jump");
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("crouching");
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the prefab at the current position and rotation
            Instantiate(bombPrefab, transform.position, transform.rotation);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void onCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    ////play random walk sound
    //int randomIndex = Random.Range(0, walkSounds.Count); // Generate a random index
    //AudioClip randomElement = walkSounds[randomIndex]; // Retrieve the element at the random index

    //audioSource.PlayOneShot(randomElement);
}
