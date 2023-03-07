using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealthSystem : MonoBehaviour
{
    public healthbar healthbar;

    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        if (currentHealth <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
