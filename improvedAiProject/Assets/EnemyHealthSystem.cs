using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public healthbar hb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hb.setMaxHealth(maxHealth);
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        hb.setHealth(currentHealth);

        if (currentHealth <= 0)
            Invoke(nameof(Die), 0.5f); 
    }
    private void Die() {
        Destroy(gameObject); 
    }
}
