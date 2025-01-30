using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] float moveThreshold = 0.1f;
    
    AsteroidSpawner asteroidSpawner;
    WaveConfigSO waveConfigSO;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        asteroidSpawner = FindObjectOfType<AsteroidSpawner>();
    }
    
    void Start()
    {
        waveConfigSO = asteroidSpawner.GetCurrentWave();
        waypoints = waveConfigSO.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FindPath();
    }

    void FindPath()
    {
        // If destination is reached then destroy game object
        if (waypointIndex >= waypoints.Count)
        {
            Destroy(gameObject);
            return;
        }
        
        // Keep finding the next waypoint and move toward it
        Vector3 targetPos = waypoints[waypointIndex].position;
        float movement = waveConfigSO.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, movement);
        
        // Check if the object is close enough to the target waypoint
        if (Vector2.Distance(transform.position, targetPos) < moveThreshold)
        {
            waypointIndex++;
        }
    }
}
