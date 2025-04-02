using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject gameUIPanel; // Your in-game UI, if any

    private void Start()
    {
        // Show start page at the beginning
        startPanel.SetActive(true);
        gameUIPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void OnPlayButton()
    {
        startPanel.SetActive(false);
        gameUIPanel.SetActive(true);
        // Add code to start the game
    }

    public void OnGameOver()
    {
        gameUIPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void OnRestartButton()
    {
        // Reload the scene or reset your game state
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
