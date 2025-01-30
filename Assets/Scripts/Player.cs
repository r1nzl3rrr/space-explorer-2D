using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float paddingLeft = .25f;
    [SerializeField] float paddingRight = .25f;
    [SerializeField] float paddingTop = 5f;
    [SerializeField] float paddingBottom = 5f;
    
    Vector2 input;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
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
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    
    // Translate the player ship with input received 
    void Move()
    {
        // Delta time will make movement frame independence
        Vector2 movement = input * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        
        // Clamp the movement to the defined bounds
        newPos.x = Mathf.Clamp(transform.position.x + movement.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + movement.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null) shooter.isFiring = value.isPressed;
    }
}
