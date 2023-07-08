using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : Singleton<SceneUtility>
{
    int currentSceneIndex => SceneManager.GetActiveScene().buildIndex;
    public void ChangeSceneByIndex(int sceneIndex = 0)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
