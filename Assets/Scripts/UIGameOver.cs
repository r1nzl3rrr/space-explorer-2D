using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    
    void Start()
    {
        scoreText.text = scoreManager.GetScore().ToString("000000000");
    }
}
