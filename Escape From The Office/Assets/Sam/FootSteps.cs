using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;  // Array to hold the footstep sound clips
    public float stepInterval = 0.5f;   // Time between each footstep sound (in seconds)
    private AudioSource audioSource;     // The AudioSource component

    private CharacterController characterController;  // Reference to the CharacterController
    private bool isWalking = false;  // Flag to check if the player is walking
    private bool isSoundPlaying = false; // Track if the sound is playing or not

    private void Start()
    {
        // Get the AudioSource component on the player object
        audioSource = GetComponent<AudioSource>();
        // Get the CharacterController component (used to detect movement)
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Check if the player is moving
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            if (!isSoundPlaying)
            {
                // Start playing the footstep sound and set it to loop
                PlayFootstepSound();
            }
        }
        else
        {
            // Stop the sound immediately if the player stops moving
            if (audioSource.isPlaying)
            {
                audioSource.Stop();  // Stop any playing sound
                isSoundPlaying = false; // Mark the sound as not playing
            }
        }
    }

    // Method to play a random footstep sound
    private void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            // Pick a random footstep sound from the array
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomIndex];  // Assign the clip to the AudioSource
            audioSource.loop = true; // Set to loop while walking
            audioSource.Play();  // Start playing the footstep sound
            isSoundPlaying = true; // Mark the sound as playing
        }
    }
}
