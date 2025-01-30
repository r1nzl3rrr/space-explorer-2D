using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    private static readonly int shipExplosion = Animator.StringToHash("ShipExplosion");
    private static readonly int asteroidExplosion = Animator.StringToHash("AsteroidExplosion");
    
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool useCameraShake;
    [SerializeField] bool isPlayer;
    
    Animator animator;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreManager scoreManager;
    LevelManager levelManager;
    
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();

        if (damage)
        {
            TakeDamage(damage.GetDamage());
            
            // Show hit particle
            PlayHitEffect();
            
            // Shake Camera
            ShakeCamera();
            
            // Play damage audio
            audioPlayer.PlayDamageClip();
            
            // Destroy the asteroid that collides with the player
            damage.Hit();
        }
    }

    void ShakeCamera()
    {
        if (cameraShake && useCameraShake)
        {
            cameraShake.Play();
        }
    }

    public int GetHealth()
    {
        return health;
    }
    
    void TakeDamage(int amount)
    {
        // Take an amount of damage specified in the damage class
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play explosion animation or add score whether is object is player or not
        if (!isPlayer)
        {
            scoreManager.AddScore(score);
            
            animator.SetTrigger(asteroidExplosion);
        }
        else
        {
            animator.SetTrigger(shipExplosion);
            
            // Load game over menu
            levelManager.LoadGameOver();
        }
        
        // Destroy game object
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffect)
        {
            ParticleSystem hitEffectIntance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEffectIntance.gameObject, 
                  hitEffectIntance.main.duration + hitEffectIntance.main.startLifetime.constantMax);
        };
    }
}
