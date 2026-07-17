using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Aparicion : MonoBehaviour
{
    [SerializeField] private Light2D light2D;
    [SerializeField] private float spped;
    [SerializeField] private float maxIntesity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (light2D.intensity < maxIntesity)
        {
            light2D.intensity += spped;
        }
    }
}
