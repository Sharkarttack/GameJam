using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private bool canChange = false;
    void Start()
    {
        StartCoroutine(prueba());
        StartCoroutine(CambiarEscena());
    }
    private IEnumerator CambiarEscena()
    {
        print("Charging Scene");
        AsyncOperation async = SceneManager.LoadSceneAsync(nextScene);
        async.allowSceneActivation = false;
        yield return new WaitUntil(CanChangeScene);
        print("Changing Scene");
        async.allowSceneActivation = true;
    }

    private bool CanChangeScene()
    {
        return canChange;
    }
    private IEnumerator prueba()
    {
        print("Start");
        yield return new WaitForSeconds(10f);
        print("Change");
        canChange = true;
    }
}
