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
        Debug.Log(scoreAmount);
        // Increase score if star is picked up by the player
        _scoreManager.AddScore(scoreAmount);
    }
}
