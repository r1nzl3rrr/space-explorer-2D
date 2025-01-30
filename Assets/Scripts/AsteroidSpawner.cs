using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    
    void Start()
    {
        SpawnAsteroids();
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    
    void SpawnAsteroids()
    {
        Instantiate(currentWave.GetAsteroid(0), 
                    currentWave.GetStartingPoint().position, 
                    Quaternion.identity,
                    transform);
    }
}
