using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class SoftFlicker : MonoBehaviour

{
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;

    private Light flicker;

    float random;

    void Start()
    {
        flicker = GetComponent<Light>();
        random = Random.Range(0.0f, 65535.0f);
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time);
        flicker.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
