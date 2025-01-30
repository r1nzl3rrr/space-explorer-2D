using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] int health = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();

        if (damage != null)
        {
            TakeDamage(damage.GetDamage());
            
            // Destroy the asteroid that collides with the player
            damage.Hit();
        }
    }

    void TakeDamage(int amount)
    {
        // Take an amount of damage specified in the damage class
        health -= amount;
        if (health <= 0)
        {
            // Destroy game object
            Destroy(gameObject);
        }
    }
}
