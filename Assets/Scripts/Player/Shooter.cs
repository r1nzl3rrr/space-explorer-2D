using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;
    
    [HideInInspector] public bool isFiring;
    
    Coroutine _firingCoroutine;
    AudioPlayer _audioPlayer;

    void Awake()
    {
        _audioPlayer = FindFirstObjectByType<AudioPlayer>();
    }
    
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        // Prevent multiple coroutine from starting
        if (isFiring && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(ConstantFiring());
        }
        else if (!isFiring && _firingCoroutine != null)
        {
            // Stop firing only when release key
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        } 
    }

    IEnumerator ConstantFiring()
    {
        while (true)
        {
            // Spawn the projectile at the player ship
            GameObject projectileToSpawn = Instantiate(projectile, 
                transform.position, Quaternion.identity);
            
            Rigidbody2D rb = projectileToSpawn.GetComponent<Rigidbody2D>();

            // Move the projectile upwards
            if (rb) rb.linearVelocity = transform.up * projectileSpeed;
            
            // Destroy the projectile after its lifetime
            Destroy(projectileToSpawn, projectileLifeTime);
            
            // Play shooting audio
            _audioPlayer.PlayShootingClip();
            
            // Wait before firing the next projectile
            yield return new WaitForSeconds(firingRate);
        }
    }
}
