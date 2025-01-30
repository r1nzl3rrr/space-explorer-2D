using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waves;
    [SerializeField] float timeBetweenWaves = 5f;
    
    WaveConfigSO currentWave;
    
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    
    IEnumerator SpawnWaves()
    {
        foreach (WaveConfigSO wave in waves)
        {
            currentWave = wave;
            
            // Start spawning asteroids for the current wave
            yield return StartCoroutine(SpawnAsteroids(currentWave));

            // Wait before starting the next wave
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        
    }

    private IEnumerator SpawnAsteroids(WaveConfigSO wave)
    {
        // Loops through a list of asteroids in that wave
        for (int i = 0; i < wave.GetAsteroidCount(); i++)
        {
            // Spawn an asteroid in the list and child it at the first waypoint
            // And add it to the Asteroid Spawner game object
            Instantiate(wave.GetAsteroid(i), 
                wave.GetStartingPoint().position, 
                Quaternion.identity,
                transform);
                
            // Wait before spawning the next asteroid
            yield return new WaitForSeconds(wave.GetRandomSpawnTime());
        }
    }
}
