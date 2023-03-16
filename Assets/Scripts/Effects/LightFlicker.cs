using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [Range(0, 10)]
    public float lightIntensity = 1;
    [Range(0, 10)]
    public float flickerIntensity = 2;
    [Range(0, 10)]
    public float lightDuration = 1;
    [Range(0, 10)]
    public float flickerDuration = 0.2f;

    private System.Random randomGenerator;
    private Light flashlight;

    private void Awake()
    {
        randomGenerator = new System.Random();
        flashlight = GetComponent<Light>();
    }

    private void Start()
    {
        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            flashlight.intensity = lightIntensity;

            float lightingTime = lightDuration + (float)(randomGenerator.NextDouble() - 0.5f) * lightDuration;
            yield return new WaitForSeconds(lightingTime);

            int flickerCount = randomGenerator.Next(4, 9);

            for (int i = 0; i < flickerCount; i++)
            {
                float flickingIntensity = lightIntensity - (float)randomGenerator.NextDouble() * flickerIntensity;
                flashlight.intensity = flickingIntensity;

                float flickingTime = (float)randomGenerator.NextDouble() * flickerDuration;
                yield return new WaitForSeconds(flickingTime);
            }
        }
    }
}
