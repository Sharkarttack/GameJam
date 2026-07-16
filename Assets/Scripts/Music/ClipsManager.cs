using UnityEngine;

public class ClipsManager : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MusicaControllerEscenas musicaController = GameObject.Find("Audio").GetComponent<MusicaControllerEscenas>();
        musicaController.ChangeMusic(clip);
    }

}
