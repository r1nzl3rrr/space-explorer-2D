using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    const string playerString = "Player";
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If interact with the player then perform pickup logic and destroy itself
        if (other.gameObject.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }
    
    protected abstract void OnPickup();
}
