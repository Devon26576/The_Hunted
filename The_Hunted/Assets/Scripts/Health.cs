using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Variables
    public int maxHealth = 100; // Initial maximum health
    public int currentHealth; // Current health will be set in Start or by other logic
    #endregion

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Update is called once per frame
    public void ChangeHealth(int damageAmount)
    {
        currentHealth += damageAmount; // Add or subtract health based on damage amount

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform death actions here, such as destroying the object
        Destroy(gameObject);
    }
}
