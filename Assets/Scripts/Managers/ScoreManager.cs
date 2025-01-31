using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score;
    static ScoreManager _instance;

    [SerializeField] int currentLevelScoreThreshold = 1000;
    [SerializeField] int scoreThresholdIncreaseAmount = 1000;
    
    GameLevelManager _gameLevelManager;
    
    void Awake()
    {
        ManageSingleton();
        _gameLevelManager = FindFirstObjectByType<GameLevelManager>();
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
        score = Mathf.Clamp(score, 0, int.MaxValue);
        
        if (score >= currentLevelScoreThreshold)
        {
            FlashTransition flashTransition = FindFirstObjectByType<FlashTransition>();
            
            flashTransition.TriggerFlash();
            _gameLevelManager.LoadNextLevel();
            currentLevelScoreThreshold += scoreThresholdIncreaseAmount;
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
