using UnityEngine;

public class Spinning : MonoBehaviour
{
    // Rotation speed in degrees
    [SerializeField] float rotationSpeed = 100f;
    
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        // Spin the object with given speed
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
}
