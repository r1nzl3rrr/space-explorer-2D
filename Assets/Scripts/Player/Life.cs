using UnityEngine;

public class Life : MonoBehaviour
{
    private static readonly int AsteroidExplosion = Animator.StringToHash("AsteroidExplosion");
    private static readonly int ShipExplosion = Animator.StringToHash("ShipExplosion");
    
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool useCameraShake;
    [SerializeField] bool isPlayer;
    [SerializeField] Animator explosionAnim;
    [SerializeField] float explosionDuration = 0.5f;

    CameraShake _cameraShake;
    AudioPlayer _audioPlayer;
    ScoreManager _scoreManager;
    GameLevelManager _gameLevelManager;
    
    void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioPlayer = FindFirstObjectByType<AudioPlayer>();
        _scoreManager = FindFirstObjectByType<ScoreManager>();
        _gameLevelManager = FindFirstObjectByType<GameLevelManager>();
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();

        if (damage)
        {
            // Take hit damage
            TakeDamage(damage.GetDamage());
            
            // Show hit particle
            PlayHitEffect();
            
            // Shake Camera
            ShakeCamera();
            
            // Play damage audio
            _audioPlayer.PlayDamageClip();
            
            // Destroy the asteroid that collides with the player
            damage.Hit();
        }
    }

    void ShakeCamera()
    {
        if (_cameraShake && useCameraShake)
        {
            _cameraShake.Play();
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
        // Instantiate a new explosion animator
        Animator explosionInstance = Instantiate(explosionAnim, 
            transform.position, Quaternion.identity);
        
        // Play explosion animation and add score whether the object is player or not
        if (!isPlayer)
        {
            explosionInstance.SetTrigger(AsteroidExplosion);
            _scoreManager.AddScore(score);
        }
        else
        {
            explosionInstance.SetTrigger(ShipExplosion);
            // Load game over menu
            _gameLevelManager.LoadGameOver();
        }
        
        // Destroy game object
        Destroy(explosionInstance.gameObject, explosionDuration);
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
