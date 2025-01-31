using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelManager : MonoBehaviour
{
    ScoreManager _scoreManager;
    
    void Awake()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    
    public void LoadGame()
    {
        // Reset score when start new game or restart game
        _scoreManager.ResetScore();
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
