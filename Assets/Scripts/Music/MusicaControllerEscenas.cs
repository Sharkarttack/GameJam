using UnityEngine;

public class MusicaControllerEscenas : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void ChangeMusic(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        
    }
}
