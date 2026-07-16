using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void ControlVolumen(float volumenSlider)
    {
        audioMixer.SetFloat("VolumenMusica", Mathf.Log10(volumenSlider)*20);
    }
}
