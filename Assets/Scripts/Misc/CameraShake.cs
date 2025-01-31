using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeAmount = 0.5f;

    Vector3 _originalPos;
    
    void Start()
    {
        _originalPos = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0f;
        while (elapsedTime < shakeDuration)
        {
            // Shake the camera in between the camera circle
            transform.position = _originalPos + (Vector3) Random.insideUnitCircle * shakeAmount;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = _originalPos;
    }
}
