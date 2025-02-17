using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    [SerializeField] string[] levels = { "Level1", "Level2", "Level3", "Level4" };

    static GameLevelManager _instance;

    void Awake()
    {
        ManageSingleton();
    }

    // Applying singleton pattern
    void ManageSingleton()
    {
        if (_instance)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadGameOver()
    {
        LoadLevel("GameOver");
    }

    private void LoadLevel(string levelName)
    {
        StartCoroutine(WaitForSceneLoad(levelName, sceneLoadDelay));
    }

    public void LoadNextLevel()
    {
        // Get the current level's index in the levels array
        string currentLevel = SceneManager.GetActiveScene().name;
        int currentLevelIndex = System.Array.IndexOf(levels, currentLevel);

        // Calculate the next level index, looping back to the first level if necessary
        int nextLevelIndex = (currentLevelIndex + 1) % levels.Length;

        // Load the next level
        LoadLevel(levels[nextLevelIndex]);
    }

    IEnumerator WaitForSceneLoad(string sceneName, float delay)
    {
        // Wait before loading the scene
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
