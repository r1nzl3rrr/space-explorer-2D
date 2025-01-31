using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] float moveThreshold = 0.1f;
    
    Spawner _spawner;
    WaveConfigSO _waveConfigSo;
    List<Transform> _waypoints;
    int _waypointIndex = 0;

    void Awake()
    {
        _spawner = FindFirstObjectByType<Spawner>();
    }
    
    void Start()
    {
        _waveConfigSo = _spawner.GetCurrentWave();
        _waypoints = _waveConfigSo.GetWaypoints();
        transform.position = _waypoints[_waypointIndex].position;
    }

    void Update()
    {
        FindPath();
    }

    void FindPath()
    {
        // If destination is reached then destroy game object
        if (_waypointIndex >= _waypoints.Count)
        {
            Destroy(gameObject);
            return;
        }
        
        // Keep finding the next waypoint and move toward it
        Vector3 targetPos = _waypoints[_waypointIndex].position;
        float movement = _waveConfigSo.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, movement);
        
        // Check if the object is close enough to the target waypoint
        if (Vector2.Distance(transform.position, targetPos) < moveThreshold)
        {
            _waypointIndex++;
        }
    }
}
