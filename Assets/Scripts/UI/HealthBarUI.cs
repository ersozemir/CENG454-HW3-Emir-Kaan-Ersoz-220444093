using UnityEngine;
using UnityEngine.UI; 

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    private void OnEnable()
    {
        // Subscribe to the CoreHealth event (Observer Pattern)
        CoreHealth.OnCoreHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        CoreHealth.OnCoreHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float healthPercentage)
    {
        // Update the slider value when notified
        if (healthSlider != null)
        {
            healthSlider.value = healthPercentage;
        }
    }
}