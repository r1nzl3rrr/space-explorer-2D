using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    private static readonly int shipExplosion = Animator.StringToHash("ShipExplosion");
    private static readonly int asteroidExplosion = Animator.StringToHash("AsteroidExplosion");
    
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool useCameraShake;
    [SerializeField] bool isPlayer;
    
    Animator animator;
    CameraShake cameraShake;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();

        if (damage != null)
        {
            TakeDamage(damage.GetDamage());
            
            // Show hit particle
            PlayHitEffect();
            
            // Shake Camera
            ShakeCamera();
            
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

    void TakeDamage(int amount)
    {
        // Take an amount of damage specified in the damage class
        health -= amount;
        if (health <= 0)
        {
            // Play explosion animation
            animator.SetTrigger(isPlayer ? shipExplosion : asteroidExplosion);

            // Destroy game object
            Destroy(gameObject);
        }
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
