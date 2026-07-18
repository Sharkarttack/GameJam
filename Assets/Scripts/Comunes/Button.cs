using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource audioPop;
    public void OnClick()
    {
        audioPop.Play();
    }
}
