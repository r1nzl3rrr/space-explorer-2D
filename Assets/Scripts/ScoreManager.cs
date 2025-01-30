using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score;

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
