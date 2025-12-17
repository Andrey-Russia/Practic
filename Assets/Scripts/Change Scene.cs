using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int SceneIndex = 1;

    public void ChangeToScene()
    {
        if (SceneIndex >= 0 && SceneIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(SceneIndex);
    }
}
