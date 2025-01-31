using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waves;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] bool isWavesLooping;

    WaveConfigSO _currentWave;
    
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return _currentWave;
    }
    
    IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waves)
            {
                _currentWave = wave;
            
                // Start spawning asteroids and stars for the current wave
                yield return StartCoroutine(SpawnObjects(_currentWave));

                // Wait before starting the next wave
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isWavesLooping);
    }

    private IEnumerator SpawnObjects(WaveConfigSO wave)
    {
        // Loops through a list of asteroids and stars in that wave
        for (int i = 0; i < wave.GetObjectCount(); i++)
        {
            // Spawn an asteroid or star in the list and child it at the first waypoint
            // And add it to the Asteroid Spawner game object
            Instantiate(wave.GetObject(i), 
                wave.GetStartingPoint().position, 
                Quaternion.identity,
                transform);
                
            // Wait before spawning the next asteroid or star
            yield return new WaitForSeconds(wave.GetRandomSpawnTime());
        }
    }
}
