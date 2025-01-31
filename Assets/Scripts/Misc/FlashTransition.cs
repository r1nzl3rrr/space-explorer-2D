using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashTransition : MonoBehaviour
{
    [SerializeField] Image flashImage;
    [SerializeField] float flashDuration = 0.2f;
    [SerializeField] float fadeSpeed = 2f;

    private void Start()
    {
        // Start with fully transparent image
        flashImage.color = new Color(1, 1, 1, 0); 
    }

    // Call this function to trigger the flash effect
    public void TriggerFlash()
    {
        StartCoroutine(FlashCoroutine());
    }

    private IEnumerator FlashCoroutine()
    {
        // Fade in (brighten the screen)
        float t = 0;
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            flashImage.color = new Color(1, 1, 1, Mathf.Clamp01(t / flashDuration)); // Increase opacity
            yield return null;
        }

        // Fade out (back to normal)
        t = 0;
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            flashImage.color = new Color(1, 1, 1, Mathf.Clamp01(1 - (t / flashDuration))); // Decrease opacity
            yield return null;
        }
    }
}