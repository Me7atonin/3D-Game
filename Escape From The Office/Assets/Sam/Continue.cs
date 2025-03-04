using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueD : MonoBehaviour
{
    public GameObject player;  // Reference to the player object (to load the correct position)
    private SaveSystemBackup saveSystem;

    void Start()
    {
        saveSystem = player.GetComponent<SaveSystemBackup>();  // Get the SaveSystem component attached to the player
    }

    // Continue button click handler
    public void Continue()
    {
        saveSystem.Load();  // Load the saved game data
        SceneManager.LoadScene("GameScene");  
    }
}

