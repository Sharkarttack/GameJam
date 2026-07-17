using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void ControlVolumen(float volumenSlider)
    {
        audioMixer.SetFloat("Volumen", Mathf.Log10(volumenSlider)*20);
    }
}
