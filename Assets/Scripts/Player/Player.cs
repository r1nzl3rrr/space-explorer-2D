using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft = .25f;
    [SerializeField] float paddingRight = .25f;
    [SerializeField] float paddingTop = 5f;
    [SerializeField] float paddingBottom = 5f;
    
    Vector2 _input;
    Vector2 _minBounds;
    Vector2 _maxBounds;

    Shooter _shooter;

    void Awake()
    {
        _shooter = GetComponent<Shooter>();
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

    void OnFire(InputValue value)
    {
        if (_shooter != null) _shooter.isFiring = value.isPressed;
    }
}
