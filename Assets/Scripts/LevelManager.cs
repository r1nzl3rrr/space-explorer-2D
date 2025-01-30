using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    
    public void LoadGame()
    {
        // Reset score when start new game or restart game
        scoreManager.ResetScore();
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitForSceneLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitForSceneLoad(string sceneName, float delay)
    {
        // Wait before loading the scene
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
