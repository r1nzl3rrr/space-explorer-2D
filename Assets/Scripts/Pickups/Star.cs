using UnityEngine;

public class Star : Pickup
{
    [SerializeField] int scoreAmount = 100;
    
    ScoreManager _scoreManager;
    AudioPlayer _audioPlayer;

    void Awake()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
        _audioPlayer = FindFirstObjectByType<AudioPlayer>();
    }

    protected override void OnPickup()
    {
        // Play pickup sound
        _audioPlayer.PlayPickupClip();
        
        // Increase score if star is picked up by the player
        _scoreManager.AddScore(scoreAmount);
    }
}
