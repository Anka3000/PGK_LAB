using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    public Material waterMaterial; 
    public Color[] colorOptions;   
    public float changeInterval = 5f; 
    private float timeSinceLastChange = 0f;
    private int currentIndex = 0;

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= changeInterval)
        {
            ChangeWaterColor();
            timeSinceLastChange = 0f;
        }
    }

    void ChangeWaterColor()
    {
        if (colorOptions != null && colorOptions.Length > 0)
        {
            currentIndex = (currentIndex + 1) % colorOptions.Length;
            Color newColor = colorOptions[currentIndex];
            waterMaterial.SetColor("_ReflectionColor", newColor);
        }
    }
}
