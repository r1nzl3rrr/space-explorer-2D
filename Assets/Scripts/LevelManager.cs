using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
    
    public void LoadGame()
    {
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
