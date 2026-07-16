using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string nextScene;
    public void OnClick()
    {
        SceneManager.LoadScene(nextScene);
    }
}
