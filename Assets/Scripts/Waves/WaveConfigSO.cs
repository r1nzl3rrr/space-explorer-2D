using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] Transform path;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenObjectSpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    
    public int GetObjectCount()
    {
        return gameObjects.Count;
    }

    public GameObject GetObject(int index)
    {
        return gameObjects[index];
    }

    public Transform GetStartingPoint()
    {
        // Return the transform of the first waypoint
        return path.GetChild(0);
    }
    
    // Get list of waypoints for path finding
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        
        // For each child in the path add it to the waypoints list
        foreach (Transform waypoint in path)
        {
            waypoints.Add(waypoint);
        }
        
        return waypoints;
    }
    
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        // Randomize the spawn time with spawn time variance
        float spawnTime = Random.Range(timeBetweenObjectSpawns - spawnTimeVariance, 
                                       timeBetweenObjectSpawns + spawnTimeVariance);
        
        // Making sure spawntime does not get below the minimum threshold
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
