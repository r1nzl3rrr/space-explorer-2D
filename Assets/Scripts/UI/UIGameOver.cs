using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    ScoreManager _scoreManager;

    void Awake()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    
    void Start()
    {
        scoreText.text = _scoreManager.GetScore().ToString("000000000");
    }
}
