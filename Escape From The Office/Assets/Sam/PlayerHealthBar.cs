using UnityEngine;
using UnityEngine.UI; // For Image and UI components
using UnityEngine.SceneManagement; // For Scene management

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;      // The player's max health
    private float currentHealth;        // The player's current health
    public Image healthBarUI;           // Reference to the UI Image for the health bar
    private bool isCollidingWithEnemy = false;
    private float damageInterval = 0.5f;  // Time between each damage while colliding (now shorter)
    private float damageAmount = 10f;   // Amount of damage per interval
    private float lastDamageTime;       // Timer to track when to apply damage

    // Public string to assign the GameOver scene in the Inspector
    public string gameOverSceneName = "GameOverScene"; // Default value, can be changed in Inspector

    void Start()  // No parameters allowed here
    {
        currentHealth = maxHealth;      // Initialize the player's health
        UpdateHealthBar();               // Update health bar at the start
    }

    void Update()  // No parameters allowed here
    {
        // Apply damage every shorter interval while colliding with an enemy
        if (isCollidingWithEnemy && Time.time - lastDamageTime >= damageInterval)
        {
            TakeDamage(damageAmount);    // Deal damage to the player
            lastDamageTime = Time.time;  // Reset the damage timer
        }

        // Check if health reaches 0 and load the game over scene
        if (currentHealth <= 0)
        {
            LoadGameOverScene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = true;
            TakeDamage(damageAmount);    // Deal damage instantly on collision
            lastDamageTime = Time.time;  // Start the damage timer immediately
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Stop damaging when the player exits the collider
        if (other.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false;
        }
    }

    void TakeDamage(float amount)
    {
        // Decrease the player's health and update the health bar
        currentHealth -= amount;
        if (currentHealth < 0f) currentHealth = 0f; // Prevent health from going below 0
        UpdateHealthBar(); // Update the health bar UI
    }

    void UpdateHealthBar()
    {
        if (healthBarUI != null)
        {
            // Update the health bar fill amount based on the player's health
            healthBarUI.fillAmount = currentHealth / maxHealth;
        }
    }

    void LoadGameOverScene()
    {
        // Load the specified scene when health hits 0
        SceneManager.LoadScene(gameOverSceneName); // This uses the scene name provided in the Inspector
    }
}
