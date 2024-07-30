using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public GameObject healthBar;
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount){
        currentHealth += amount;
        if(currentHealth > maxHealth)
            currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void Damage(int amount){
        currentHealth -= amount;
        if(currentHealth < 0)
            currentHealth = 0;
        UpdateHealthBar();
    }

    public void UpdateHealthBar() {
        healthBar.transform.localScale = new Vector3(
            currentHealth * 1f / maxHealth * 1f,
            healthBar.transform.localScale.y,
            healthBar.transform.localScale.z
        );
    }
}
