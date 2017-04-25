using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float maxHealth = 100f;

    private float currentHealth;
    private bool dead = false;

    void Start() {
        currentHealth = maxHealth;
    }

    void Update() {
        if (currentHealth <= 0.0f) dead = true;
    }

    public void Damage(float amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) currentHealth = 0;
    }

    public void Heal(float amount) {
        currentHealth += amount;
        if (currentHealth >= maxHealth) currentHealth = maxHealth;
    }

    public float GetHealth() {
        return currentHealth;
    }

    public float GetHealthPercentage() {
        return currentHealth / maxHealth;
    }

    public bool IsDead() {
        return dead;
    }
}
