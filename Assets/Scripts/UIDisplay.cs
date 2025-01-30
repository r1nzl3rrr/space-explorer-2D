using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] HealthPoint playerHealth;
    
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    
    void Start()
    {
        // Link the maximum value of the health bar to the player health
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        // Update health bar and score text on the UI
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreManager.GetScore().ToString("00000000000");
    }
}
