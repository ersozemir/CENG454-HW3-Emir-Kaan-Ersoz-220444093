using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Text statusText; 
    [SerializeField] private GameObject endScreenPanel; // The panel that shows the end game status and restart button
    [SerializeField] private int targetKills = 20;
    
    private int _currentKills = 0;
    private bool _isGameOver = false;

    private void Awake()
    {
        Instance = this;
        // Hide end screen at the start of the game
        if(statusText != null) statusText.text = "";
        if(endScreenPanel != null) endScreenPanel.SetActive(false);
        
        // Back to normal time scale in case it was changed in a previous game session
        Time.timeScale = 1;
    }

    public void AddScore()
    {
        if (_isGameOver) return;
        _currentKills++;
        Debug.Log("Kills: " + _currentKills);

        if (_currentKills >= targetKills)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        _isGameOver = true;
        statusText.text = "MISSION ACCOMPLISHED!\nYOU WIN";
        statusText.color = Color.green;
        EndGame();
    }

    public void GameOver()
    {
        _isGameOver = true;
        statusText.text = "CORE DESTROYED!\nGAME OVER";
        statusText.color = Color.red;
        EndGame();
    }

    private void EndGame()
    {
        if(endScreenPanel != null) endScreenPanel.SetActive(true); // Paneli/Butonu göster
        Time.timeScale = 0; // Stop the game
    }

    //retry button 
    public void RestartGame()
    {
        Time.timeScale = 1; // Traverse time back to normal before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Normal scene reload for restart
    }
}