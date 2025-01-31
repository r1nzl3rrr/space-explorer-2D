using UnityEngine;

public class Star : Pickup
{
    [SerializeField] int scoreAmount = 100;
    
    ScoreManager _scoreManager;

    void Awake()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        _scoreManager.AddScore(scoreAmount);
    }
}
