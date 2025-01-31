using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score;
    static ScoreManager _instance;
    
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
    
    public int GetScore()
    {
        return score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        
        // Clamp the score to not be less than 0
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
