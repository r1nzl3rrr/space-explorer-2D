using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft = .25f;
    [SerializeField] float paddingRight = .25f;
    [SerializeField] float paddingTop = 5f;
    [SerializeField] float paddingBottom = 5f;
    
    [SerializeField] private AudioClip mainThrustSfx;
    [SerializeField] private ParticleSystem mainThrustParticles;
    [SerializeField] private ParticleSystem rightThrustParticles;
    [SerializeField] private ParticleSystem leftThrustParticles;
    
    Vector2 _input;
    Vector2 _minBounds;
    Vector2 _maxBounds;

    Shooter _shooter;
    AudioSource _audio;

    void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _audio = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        InitBounds();
    }
    
    // Update every frame
    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        ProcessThrust();
    }

    // Define the movement bound of the player based on camera viewport
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    
    // Translate the player ship with input received 
    void Move()
    {
        // Delta time will make movement frame independence
        Vector2 movement = _input * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        
        // Clamp the movement to the defined bounds
        newPos.x = Mathf.Clamp(transform.position.x + movement.x, _minBounds.x + paddingLeft, _maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + movement.y, _minBounds.y + paddingBottom, _maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    void ProcessThrust()
    {
        if (!_audio.isPlaying)
        {
            _audio.PlayOneShot(mainThrustSfx);
        }
        
        // Toggle main thrust on or off based on y input
        if (_input.y > 0)
        {
            mainThrustParticles.Play();
        }
        else if (_input.y <= 0)
        {
            mainThrustParticles.Stop();
        }
        
        // Use left or right thrust based on x input
        if (_input.x > 0)
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Play();
        }
        else if (_input.x < 0)
        {
            leftThrustParticles.Stop();
            rightThrustParticles.Play();
        }

        // Stop all thrusters when no input was detected
        if (_input is { x: 0, y: <= 0 })
        {
            StopThrusting();
        }
    }
    
    void StopThrusting()
    {
        _audio.Stop();
        mainThrustParticles.Stop();
        leftThrustParticles.Stop();
        rightThrustParticles.Stop();
    }
    
    void OnFire(InputValue value)
    {
        if (_shooter != null) _shooter.isFiring = value.isPressed;
    }
}
