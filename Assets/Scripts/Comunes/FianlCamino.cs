using UnityEngine;
using UnityEngine.SceneManagement;

public class FianlCamino : MonoBehaviour
{
    [SerializeField] private string nextScene;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() is PlayerController)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
