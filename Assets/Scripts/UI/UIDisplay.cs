using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [FormerlySerializedAs("playerHealth")] [SerializeField] Life playerLife;
    
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManager _scoreManager;

    void Awake()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    
    void Start()
    {
        // Link the maximum value of the health bar to the player health
        healthSlider.maxValue = playerLife.GetHealth();
    }

    void Update()
    {
        // Update health bar and score text on the UI
        healthSlider.value = playerLife.GetHealth();
        scoreText.text = _scoreManager.GetScore().ToString("00000000000");
    }
}
