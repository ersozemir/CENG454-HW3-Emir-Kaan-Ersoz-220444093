using UnityEngine;
using System; 

public class CoreHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    // Observer Pattern: Notifies subscribers when health changes
    public static event Action<float> OnCoreHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        // Notify all observers (UI, Sound, VFX) with the current health ratio
        OnCoreHealthChanged?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Core Breached! Game Over.");
            // Logic for Lose Condition (Task 2.1)
        }
    }
}