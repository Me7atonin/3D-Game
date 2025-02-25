using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Image healthBarUI;
    private bool isCollidingWithEnemy = false;
    private float damageInterval = 0.5f;
    private float damageAmount = 10f;
    private float lastDamageTime;
    public string gameOverSceneName = "GameOverScene";

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (isCollidingWithEnemy && Time.time - lastDamageTime >= damageInterval)
        {
            TakeDamage(damageAmount);
            lastDamageTime = Time.time;
        }

        if (currentHealth <= 0)
        {
            LoadGameOverScene();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = true;
            TakeDamage(damageAmount);
            lastDamageTime = Time.time;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false;
        }
    }

    void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0f) currentHealth = 0f;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBarUI != null)
        {
            healthBarUI.fillAmount = currentHealth / maxHealth;
        }
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
