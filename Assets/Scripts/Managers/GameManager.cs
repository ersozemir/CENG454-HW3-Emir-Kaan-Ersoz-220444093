using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;

    private void OnEnable()
    {
        // Listens the event when the core health changes
        CoreHealth.OnCoreHealthChanged += CheckGameOver;
    }

    private void OnDisable()
    {
        CoreHealth.OnCoreHealthChanged -= CheckGameOver;
    }

    private void CheckGameOver(float healthPercentage)
    {
        // If health drops to 0 or below
        if (healthPercentage <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        losePanel.SetActive(true); // Show the lose panel
        Time.timeScale = 0f;      // Stop the game time
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;      // Resume the game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the scene
    }
}